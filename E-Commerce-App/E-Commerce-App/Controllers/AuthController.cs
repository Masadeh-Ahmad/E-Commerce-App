using E_Commerce_App.Auth.Interfaces;
using E_Commerce_App.Auth.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_App.Controllers
{
    public class AuthController : Controller
    {
        private IUserService userService;

        public AuthController(IUserService userSer)
        {
            userService = userSer;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> SignUp(RegisterDto register)
        {
            var user = await userService.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return View();
        }

        public async Task<ActionResult<UserDto>> Authenticate(LoginDTO login)
        {
            HttpContext.Session.Clear();
            var user = await userService.Authenticate(login.UserName, login.Password);
            if (user == null)
            {             
                return RedirectToAction("Index");
            }

            return Redirect("/");
        }
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
