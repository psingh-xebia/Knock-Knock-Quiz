using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Knock_Knock_Quiz.App.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {

            var secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("a secret that needs to be at least 16 characters long"));

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, "Username"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken
            (
                issuer: "Issuer",
                audience:"Audience",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(secretKey,
                        SecurityAlgorithms.HmacSha256)
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}