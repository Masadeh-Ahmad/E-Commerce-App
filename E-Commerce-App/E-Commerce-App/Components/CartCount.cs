using E_Commerce_App.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_App.Components
{
    public class CartCount : ViewComponent
    {
        private IUserService _userService;
        public CartCount(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = await _userService.getCart(User.Identity.Name);
            ViewComponentModel cartData = new ViewComponentModel() { count = "0"};        
            return View(cartData);
        }

        public class ViewComponentModel
        {
            public string count { get; set; }
        }
    }
}
