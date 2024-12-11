using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using Authentication.Models.Repositories.Abstract;
using Authentication.Models.Model.RegisteredUsers;
using Authentication.Models.Model;
using Authentication.Api.Settings;

namespace Authentication.Api.Controllers
{
    public class AuthorizeController : Controller
    {
        private readonly IUserService userService;

        public AuthorizeController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> GenerateToken(RegisteredUserCredentialsModel registeredUserCredentials)
        {
            var user = await userService.GetRegisteredUser(registeredUserCredentials);

            if (user != null)
            {
                //generate token
                var tokenhandler = new JwtSecurityTokenHandler();

                var tokenkey = Encoding.UTF8.GetBytes(JwtTokenSettings.JwtKey);
                var tokendesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.Name,registeredUserCredentials.UserName),
                        new Claim(ClaimTypes.Role,user.Role)
                    ]),

                    Expires = DateTime.UtcNow.AddSeconds(3000),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenhandler.CreateToken(tokendesc);

                var finaltoken = tokenhandler.WriteToken(token);

                return Ok(new TokenResponse() {
                    Token = finaltoken, 
                    //RefreshToken = await this.refresh.GenerateToken(registeredUserCredentials.UserName),
                    UserRole = user.Role 
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
