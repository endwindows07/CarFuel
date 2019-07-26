using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarFuel.Web.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarFuel.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<LoginModel> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;

        public AuthController(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, UserManager<IdentityUser> userManager , IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.logger = logger;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<AuthResponse>> Post(AuthRequest item)
        {
            var result = await signInManager.PasswordSignInAsync(item.UserName, item.Password, false, false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(item.UserName);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, item.UserName),
                    new Claim("Id", user.Id),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //var x1 = configuration["JWT:issuer"];
                //var x2 = configuration["JWT:audience"];
                //var x3 = DateTime.Now.AddMinutes(int.Parse(configuration["JWT:exp"].ToString()));

                var token = new JwtSecurityToken(
                    issuer: configuration["JWT:issuer"],
                    audience: configuration["JWT:audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(int.Parse(configuration["JWT:exp"].ToString())),
                    signingCredentials: creds);

                return Ok(new AuthResponse { Token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest();
        }

    }

    public class AuthRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
    }

}
