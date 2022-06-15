using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_App.Components
{
    public class CartCount : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewComponentModel cartData = new ViewComponentModel { Name = HttpContext.Request.Cookies["username"] };
            return View(cartData);
        }

        public class ViewComponentModel
        {
            public string Name { get; set; }
        }
    }
}
