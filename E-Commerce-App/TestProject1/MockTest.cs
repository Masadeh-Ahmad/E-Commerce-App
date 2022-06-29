using E_Commerce_App.Models;
using E_Commerce_App.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace TestProject1
{
    public class MockTest : Mock
    {
        [Fact]
        public async Task AddCategorieTest()
        {
            var Categorie = await CreateAndSaveTestCategorie();
            var repository = new CategoriesService(_db);
            Assert.Equal(5, Categorie.Id);
        }
        [Fact]
        public async Task AddCategorieTest2()
        {
            var categorie = new Categorie { CategoryName = "INDOOR PLANTS ", CategoryDescription = "Add a touch of natural beauty to your place! Through a variety of indoor ornamental plants equipped in containers and basins, in addition to large and small flowering indoor plants." } ;
            var repository = new CategoriesService(_db);
            await repository.Create(categorie);
            var newCat = await repository.Details(5);
            Assert.Equal("INDOOR PLANTS ", newCat.CategoryName);
        }
        [Fact]
        public async Task DeleteCategorieTest()
        {
            var Categorie = await CreateAndSaveTestCategorie();
            var repository = new CategoriesService(_db);
            Assert.Equal(5, Categorie.Id);
            await repository.DeleteConfirmed(5);
            var newCat = await repository.Details(5);
            Assert.Null(newCat);
        }
        [Fact]
        public async Task AddProductTest()
        {

            var product = new Product { CategoryId = 0, Description = "Test", Name = "Test", price = 100, ProductImage = "test", stock = true, };
            var repository = new ProductsService(_db);
            await repository.Create(product);
            var newProduct = await CreateAndSaveTestProduct();
            Assert.Equal(product.Name, newProduct.Name);

        }
    }
}
