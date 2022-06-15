using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Models.Interface
{
    public interface IProducts
    {
        public Task<List<Product>> Index();
        public Task<Product> Details(int? id);
        public Task<Product> Create(Product product);
        public Task<Product> Edit(int? id);
        public  Task<Product> Edit(int id,Product product);
        public Task<Product> Delete(int? id);
        public Task DeleteConfirmed(int id);
        public bool ProductExists(int id);

    }
}
