using E_Commerce_App.Auth.Interfaces;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Components
{
    public class CartCount : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = HttpContext.Session.GetString("cart");
            ViewComponentModel cartData = new ViewComponentModel();
            if (cart == null)
            {
                cartData = new ViewComponentModel() { count = "0" };
            }
            else
            {
                List<Item> dataCart = JsonConvert.DeserializeObject<List<Item>>(cart);
                int all = 0;
                foreach(Item item in dataCart)
                {
                    all += item.Quantity;
                }
                cartData = new ViewComponentModel() { count = $"{all}" };
            }    
            return View(cartData);
        }

        public class ViewComponentModel
        {
            public string count { get; set; }
        }
    }
}
