using E_Commerce_App.Auth.Interfaces;
using E_Commerce_App.Auth.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace E_Commerce_App.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private IUserService userService;
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public IndexModel(IUserService userSer)
        {
            userService = userSer;
        }
        public async Task OnPostAsync()
        {
            await userService.Authenticate(UserName, Password);
            
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new System.DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("username", UserName, cookieOptions);


        }
    }
}
