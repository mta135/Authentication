using Authentication.Models.Model;
using Authentication.Models.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse))]
        public async  Task<IActionResult> UserRegister(UserRegistration userRegistration)
        {
            APIResponse userRegisterResult = await userService.UserRegister(userRegistration);

            return Ok(userRegisterResult);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse))]
        public async Task<IActionResult> ConfirmRegisteration(RegisterConfirm confirmPassword)
        {
            APIResponse data = await userService.ConfirmRegister(confirmPassword.UserId, confirmPassword.UserName, confirmPassword.OptText);

            return Ok(data);
        }
    }
}
