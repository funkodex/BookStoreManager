using DataAccess.Models;
using DataAccess.Models.Entities;
using InventoryManagerBackend.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventoryManagerBackend.Services
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegistrationInfo info);

        Task<AuthResult> AuthenticateAsync(Credentials credentials);
        Task<PasswordRecoveryResult> SendPasswordRecoveryEmailAsync(Credentials credentials);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        private readonly JwtOptions _jwt;

        public AuthService(UserManager<AppUser> userManager, IOptions<JwtOptions> jwt, IMailService mailService)
        {
            _userManager = userManager;
            _mailService = mailService;
            _jwt = jwt.Value;
        }
        public async Task<AuthResult> RegisterAsync(RegistrationInfo info)
        {
            List<string> errors = new();
            if (await _userManager.FindByEmailAsync(info.Email) is not null)
            {
                errors.Add("Email is already registered");
            }

            var user = new AppUser()
            {
                FirstName = info.FirstName,
                LastName = info.LastName,
                UserName = info.UserName,
                Email = info.Email,
            };
            var result = await _userManager.CreateAsync(user, info.Password);

            if (!result.Succeeded)
            {
                errors.AddRange(result.Errors.Select(err => err.Description).ToList());
                return new() { Errors = errors };
            }
            var addRolesResult = await _userManager.AddToRoleAsync(user, "Basic");

            if (!addRolesResult.Succeeded)
            {
                errors.AddRange(addRolesResult.Errors.Select(err => err.Description).ToList());
                return new() { Errors = errors };
            }
            var token = await CreateTokenAsync(user);
            return new()
            {
                ExpiresIn = token.ValidTo,
                IsAuthenticated = true,
                Roles = new() { "Basic" },
                Token = token.AsString(),
                Errors = errors
            };
        }


        public async Task<AuthResult> AuthenticateAsync(Credentials credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, credentials.Password))
            {
                return new() { Errors = new() { "Email or password incorrect" } };
            }
            var token = await CreateTokenAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            return new()
            {
                IsAuthenticated = true,
                Token = token.AsString(),
                ExpiresIn = token.ValidTo,
                Roles = roles.ToList(),
                Errors = new() { }
            };
        }


        public async Task<JwtSecurityToken> CreateTokenAsync(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roleClaims = (await _userManager.GetRolesAsync(user)).Select(r => new Claim("Roles", r)).ToList();

            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub,user.UserName),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Email,user.Email),
                new("uid",user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
            (
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(_jwt.DurationInHours),
                signingCredentials: signingCredentials
            );
            return token;
        }

        public async Task<PasswordRecoveryResult> SendPasswordRecoveryEmailAsync(Credentials credentials)
        {
            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user is null)
            {
                return new()
                {
                    Errors = new() { "Email is incorrect or account doesn't exist" }
                };
            }
            var request = new MailRequest()
            {
                Recipient = credentials.Email,
                Subject = "Password Recovery",
                Body = $"{user.UserName} use the confirmation code to reset your passowrd {Guid.NewGuid().ToString().Substring(0, 8)}"
            };
            await _mailService.SendEmailAsync(request);
            return new() { IsEmailSent = true };
        }
    }


}
