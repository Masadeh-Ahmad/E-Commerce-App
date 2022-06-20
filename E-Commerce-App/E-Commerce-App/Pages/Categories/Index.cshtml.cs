using E_Commerce_App.Models;
using E_Commerce_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategories _categories;

        [BindProperty]
        public List<Categorie> cat { set; get; }

        public IndexModel(ICategories categories)
        {
            _categories = categories;
        }

        public async Task OnGet()
        {
             cat = await _categories.Index();


        }
    }
}
