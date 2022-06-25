using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using E_Commerce_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs.Models;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure.Management.Storage.Models;
using E_Commerce_App.Models.ViweModel;
using E_Commerce_App.Auth.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace E_Commerce_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _product;
        private readonly IConfiguration _Configuration;
        private readonly IUserService _userService;
        private readonly IMemoryCache _memoryCache;

        public ProductsController(IProducts product, IConfiguration config, IUserService userService, IMemoryCache memoryCache)
        {
            _product = product;
            _Configuration = config;
            _userService = userService;
            _memoryCache = memoryCache;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _product.Index());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _product.Details(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize(Roles = "Administrator")]

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create( Product product, IFormFile file)
        {
            BlobContainerClient container = new BlobContainerClient(_Configuration.GetConnectionString("AzWA"), "dbplant");

            await container.CreateIfNotExistsAsync();
            BlobClient blob = container.GetBlobClient(file.FileName);
            using var stream = file.OpenReadStream();
            BlobUploadOptions options = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders() { ContentType = file.ContentType }
            };
            if (!blob.Exists())
            {
                await blob.UploadAsync(stream, options);
            }

            product.ProductImage = blob.Uri.ToString();
            if (ModelState.IsValid)
            {
                await _product.Create(product);
                return RedirectToAction("Index");
            }
            stream.Close();
            return View(product);
            
        }

        // GET: Products/Edit/5
        [Authorize(Policy = "Editor")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _product.Edit(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,price,Description,stock,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _product.Edit(id, product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [Authorize(Policy = "Administrator")]

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _product.Delete(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _product.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddProductToCart(int id,string username)
        {


            var product = await _product.Details(id);
            //List < Product > products = new List<Product>();
            //Cart cart = await _userService.getCart(username);
            //products.Add(product);

            
            Cartpro.Products.Add(product);
            string urlAnterior = Request.Headers["Referer"].ToString();
            return Redirect(urlAnterior);


        }

        private bool ProductExists(int id)
        {
            return _product.ProductExists(id);
        }
    }
}
