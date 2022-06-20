using E_Commerce_App.Auth.Interfaces;
using E_Commerce_App.Auth.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace E_Commerce_App.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private IUserService userService;

        public IndexModel(IUserService userSer)
        {
            userService = userSer;
        }
        public async Task OnGet(LoginDTO login)
        {
            var user = await userService.Authenticate(login.UserName, login.Password);
          
           
        }
    }
}
