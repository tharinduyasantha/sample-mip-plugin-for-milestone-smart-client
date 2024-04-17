using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MIPPlugin1.Client.Services
{
    public class TokenService
    {
        private readonly string _secretKey;

        public TokenService(string secretKey)
        {
            _secretKey = secretKey;
        }

        public string RegenerateToken(string originalToken)
        {
            // First, validate the incoming token's structure and decode it without validating its signature.
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(originalToken);
            var originalKid = jwtToken.Header.Kid;

            // Extract the claims from the original token.
            var claims = jwtToken.Claims;

            // Create the signing key for the new token.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey))
            {
                KeyId = originalKid  // Set the 'kid' value from the original token
            };
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Generate the new token using the same claims from the original token.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credentials
            };

            // Create and return the new token.
            var newToken = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(newToken);
        }

    }
}
