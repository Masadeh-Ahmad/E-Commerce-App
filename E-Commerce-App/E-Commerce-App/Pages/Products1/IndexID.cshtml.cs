using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.Pages.Prodects
{
    public class IndexIDModel : PageModel
    {
        private readonly E_Commerce_App.Data.EcommercelDbContext _context;

        public IndexIDModel(E_Commerce_App.Data.EcommercelDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }

        public async Task OnGetAsync(int id)
        {
            Product = await _context.Products.Where(x => x.CategoryId == id).ToListAsync();
        }
    }
}
