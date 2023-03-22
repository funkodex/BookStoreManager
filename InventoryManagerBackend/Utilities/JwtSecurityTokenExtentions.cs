using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace InventoryManagerBackend.Utilities
{
    public static class JwtSecurityTokenExtentions
    {
        private static readonly JwtSecurityTokenHandler tokenHandler = new();

        public static string AsString(this SecurityToken token)
        {
            return tokenHandler.WriteToken(token);
        }
    }
}
