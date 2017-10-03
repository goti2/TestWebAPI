using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace TestWebAPI.Services
{
    public class DefaultTokenService : ITokenService
    {
        private IConfiguration config;
        
        public DefaultTokenService(IConfiguration configuration)
        {
            this.config = configuration;
        }

        public string CreateToken(string username, string email, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                new Claim(ClaimTypes.Email,email)
            };
            
            claims.AddRange(roles.Select( role =>  new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));
            
            var signinKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["JWT:key"]));
            
            var jwt = new JwtSecurityToken
            (
                issuer: config["JWT:issuer"],
                audience: config["JWT:audience"],
                notBefore: DateTime.Now,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Double.Parse(config["JWT:expires"])),
                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha512)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}