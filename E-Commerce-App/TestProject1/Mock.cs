using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly EcommercelDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new EcommercelDbContext(
                new DbContextOptionsBuilder<EcommercelDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
        [Fact]

        protected async Task<Categorie> CreateAndSaveTestCategorie()
        {
            var Categorie = new Categorie { CategoryName = "INDOOR PLANTS ", CategoryDescription = "Add a touch of natural beauty to your place! Through a variety of indoor ornamental plants equipped in containers and basins, in addition to large and small flowering indoor plants." };
            _db.Categories.Add(Categorie);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, Categorie.Id);
            return Categorie;
        }

        protected async Task<Product> CreateAndSaveTestProduct()
        {
            var product = new Product {  CategoryId=0,Description="Test", Name="Test", price=100,ProductImage="test", stock=true,  };
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, product.Id);
            return product;
        }
    }
}
