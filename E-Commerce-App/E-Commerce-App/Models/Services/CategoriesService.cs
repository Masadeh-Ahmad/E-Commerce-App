using E_Commerce_App.Data;
using E_Commerce_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.Models.Services
{
    public class CategoriesService : ICategories
    {
        private readonly EcommercelDbContext _context;

        public CategoriesService(EcommercelDbContext context)
        {
            _context = context;
        }
        public bool CategorieExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        public async Task<Categorie> Create(Categorie categorie)
        {
            _context.Add(categorie);
            await _context.SaveChangesAsync();
            return categorie;

        }

        public async Task<Categorie> Delete(int? id)
        {
            return await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            var categorie = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categorie);
            await _context.SaveChangesAsync();    
        }

        public async Task<Categorie> Details(int? id)
        {
            return await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Categorie> Edit(int? id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Categorie> Edit(int id, Categorie categorie)
        {
            _context.Update(categorie);
            await _context.SaveChangesAsync();
            return categorie;
        }

        public async Task<List<Categorie>> Index()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
