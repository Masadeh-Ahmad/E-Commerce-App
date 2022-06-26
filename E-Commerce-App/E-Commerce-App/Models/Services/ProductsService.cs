using E_Commerce_App.Data;
using E_Commerce_App.Models.Interface;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.Models.Services
{
    public class ProductsService : IProducts
    {
        private readonly EcommercelDbContext _context;

        public ProductsService(EcommercelDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            if (_context.Categories.Any(x => x.Id == product.CategoryId))
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

            }

            return product;
        }

        public async Task<Product> Delete(int? id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Details(int? id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Product> Edit(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Edit(int id, Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> Index()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<List<Product>> getCat(int id)
        {
            return await _context.Products.Where(x=>x.CategoryId==id).ToListAsync();
        }
        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
