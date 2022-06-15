using E_Commerce_App.Models;
using E_Commerce_App.Models.ViweModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace E_Commerce_App.Pages
{
    public class CartRazModel : PageModel
    {
        public List<Product> products;
        public void OnGet()
        {
            products = Cartpro.Products;


        }
    }
}
