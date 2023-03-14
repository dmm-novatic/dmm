using Microsoft.IdentityModel.Tokens;
using Novatic.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Text;

namespace Novatic.Services
{
    //190822 Harry add token logic
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, Account user);
        bool ValidateToken(string key, string issuer, string token);
    }
    public class TokenService : ITokenService
    {
        private const int EXPIRY_DURATION_MONTHS = 1;

        public string BuildToken(string key, string issuer, Account user)
        {
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("Id", user.Id.ToString()),
                new Claim("AccountTypeId", user.AccountTypeId.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddMonths(EXPIRY_DURATION_MONTHS), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public bool ValidateToken(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = issuer,
                        ValidAudience = issuer,
                        RequireExpirationTime = true,
                        IssuerSigningKey = mySecurityKey,
                    }, out SecurityToken validatedToken);

            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
