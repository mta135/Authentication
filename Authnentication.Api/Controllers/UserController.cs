using Microsoft.AspNetCore.Mvc;

namespace Authentication.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
