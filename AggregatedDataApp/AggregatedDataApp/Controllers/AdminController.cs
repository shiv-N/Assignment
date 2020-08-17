using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Models;
using CommonLayer.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AggregatedDataApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL adminBL;
        private IConfiguration configuration { get; }

        public AdminController(IAdminBL adminBL, IConfiguration configuration)
        {
            this.adminBL = adminBL;
            this.configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult AdminLogin(AdminLoginModel loginModel)
        {
            try
            {
                AdminLoginResponse result = this.adminBL.AdminLogin(loginModel);

                if (result.Id != 0)
                {
                    result.Token = GenrateJWTToken(result.Email, result.Id);
                    return this.Ok(new { success = true, Message = "Login successful",data=result});
                }
                else
                {
                    return this.NotFound(new { success = false, Message = "Login unsuccessful" });
                }
            }
            catch(Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }

        private string GenrateJWTToken(string email, int id)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Data:Key"]));
            var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
            string userId = Convert.ToString(id);
            var claims = new List<Claim>
                        {
                            new Claim("email", email),
                            new Claim("id",userId),

                        };
            var tokenOptionOne = new JwtSecurityToken(

                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials
                );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptionOne);
            return token;
        }
    }
}
