using E_Commerce_App.Auth.Models;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace E_Commerce_App.Data
{

    public class EcommercelDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public EcommercelDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categorie>().HasData(
              new Categorie { Id = 1, CategoryName = "INDOOR PLANTS ", CategoryDescription = "Add a touch of natural beauty to your place! Through a variety of indoor ornamental plants equipped in containers and basins, in addition to large and small flowering indoor plants." },
              new Categorie { Id = 2, CategoryName = "OUTDOOR PLANTS ", CategoryDescription = "A variety of outdoor plants that can be used in open spaces such as the garden of the house or around the walls and entrances of the house" },
             new Categorie { Id = 3, CategoryName = "Bedroom Plants ", CategoryDescription = "Bedroom plants can do more than just make your shelves look brighter. They can also boost your mood, enhance your creativity, reduce your stress levels, increase your productivity, naturally filter air pollutants, and much more. " },
          new Categorie { Id = 4, CategoryName = "Jungle Plants ", CategoryDescription = "Null" });


            SeedRole(modelBuilder, "Administrator", "Administrator", "Editor");
            SeedRole(modelBuilder, "Editor", "Editor");

        }
        private int nextId = 1; // we need this to generate a unique id on our own
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions", // This matches what we did in Startup.cs
                ClaimValue = permission
            }).ToArray();
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }


    }

}
