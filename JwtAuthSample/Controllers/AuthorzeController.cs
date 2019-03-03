using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JwtAuthSample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace JwtAuthSample.Controllers
{
    //[Route("[controller]/[action]")]
    public class AuthorizeController : ControllerBase
    {
        private JwtSettings _jwtSettings;

        public AuthorizeController(IOptions<JwtSettings> jwtSettingsAccess)
        {

            _jwtSettings = jwtSettingsAccess.Value;
        }

        [HttpPost]
        public IActionResult Token(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(!(viewModel.User == "luochuanwei" && viewModel.PassWord == "123456"))
            {
                return BadRequest();
            }

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, viewModel.User),
                new Claim(ClaimTypes.Role, "admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claims, DateTime.Now, DateTime.Now.AddMinutes(30), creds);

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token)});
        }
    }
}
