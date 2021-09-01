using AgmApp.Core.Entities;
using AgmApp.Core.Handlers.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AgmApp.Core
{
    public class AuthHandler : IAuthHandler
    {
        readonly IConfiguration _conf;

        public AuthHandler(IConfiguration conf)
        {
            this._conf = conf;
        }

        public string GenerateJWT(User user)
        {

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._conf["Authentication:SecretKey"]));
            var sigInCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sigInCredentials);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var payLoad = new JwtPayload(
                issuer: this._conf["Authentication:Issuer"],
                audience: this._conf["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.Now.AddMinutes(30)
                );

            var token = new JwtSecurityToken(header, payLoad);

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }
}
