using E_Commerce_App.Auth;
using E_Commerce_App.Auth.Interfaces;
using E_Commerce_App.Auth.Models;
using E_Commerce_App.Controllers;
using E_Commerce_App.Data;
using E_Commerce_App.Models.Interface;
using E_Commerce_App.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMvc();
            
            services.AddTransient<ICategories, CategoriesService>();
            services.AddTransient<IProducts, ProductsService>();
            services.AddTransient<IUserService, UserService>();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<EcommercelDbContext>();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("permissions", "Administrator"));
                options.AddPolicy("Editor", policy => policy.RequireClaim("permissions", "Editor"));
            });

         

            services.AddDbContext<EcommercelDbContext>(options =>
            {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
            app.UseStaticFiles();
            
        }
    }
}
