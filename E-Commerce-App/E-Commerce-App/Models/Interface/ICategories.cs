using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Models.Interface
{
    public interface ICategories
    {
        public Task<List<Categorie>> Index();
        public Task<Categorie> Details(int? id);
        public Task<Categorie> Create(Categorie categorie);
        public Task<Categorie> Edit(int? id);
        public Task<Categorie> Edit(int id, Categorie categorie);
        public Task<Categorie> Delete(int? id);
        public Task DeleteConfirmed(int id);
        public bool CategorieExists(int id);
    }
}
