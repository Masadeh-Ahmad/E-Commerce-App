using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using E_Commerce_App.Data;
using E_Commerce_App.Models;

namespace E_Commerce_App.Pages.Prodects
{
    public class indexModel : PageModel
    {
        private readonly E_Commerce_App.Data.EcommercelDbContext _context;

        public indexModel(E_Commerce_App.Data.EcommercelDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync(int id)
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
