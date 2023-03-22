using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryManagerBackend.Controllers.Mvc
{

    //public class AuthController : Controller
    //{
    //    [HttpGet("login")]
    //    public IActionResult Login()
    //    {
    //        return View("Login");
    //    }

    //    [HttpPost("login")]
    //    public async Task<IActionResult> LoginPost(string username, string password)
    //    {
    //        var claims = new List<Claim>() {
    //            new("username",username),
    //            new(ClaimTypes.NameIdentifier,username),
    //        };
    //        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    //        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    //        await HttpContext.SignInAsync(claimsPrincipal);
    //        return Redirect("/api/payment");
    //    }
    //    [HttpGet("/logout")]
    //    [Authorize]
    //    public async Task<IActionResult> Logout(string username, string password)
    //    {

    //        await HttpContext.SignOutAsync();
    //        return Redirect("/api/payment");
    //    }
    //}
}
