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
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AuthorizeController : Controller
    {
        private readonly IUserService userService;

        private readonly IRefreshHandler refreshHandler;

        public AuthorizeController(IUserService userService, IRefreshHandler refreshHandler)
        {
            this.userService = userService;
            this.refreshHandler = refreshHandler;
        }

        //[HttpPost]
        //public async Task<IActionResult> GenerateToken(UserCredentialsModel userCredentials)
        //{
        //    RegisteredUser user = await userService.GetRegisteredUser(userCredentials);

        //    if (user != null)
        //    {
        //        //generate token
        //        var tokenhandler = new JwtSecurityTokenHandler();

        //        var tokenkey = Encoding.UTF8.GetBytes(JwtTokenSettings.JwtKey);
        //        var tokendesc = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(
        //            [
        //                new Claim(ClaimTypes.Name,userCredentials.UserName),
        //                //new Claim(ClaimTypes.Role,user.Role)
        //            ]),

        //            Expires = DateTime.UtcNow.AddSeconds(3000),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
        //        };

        //        var token = tokenhandler.CreateToken(tokendesc);

        //        var finaltoken = tokenhandler.WriteToken(token);

        //        return Ok(new TokenResponse()
        //        {
        //            Token = finaltoken, 

        //            RefreshToken = await refreshHandler.GenerateToken(user.Id),
                    
        //            UserRole = user.Role 
        //        });
        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }
        //}
    }
}
