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

namespace E_Commerce_App.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategories _categories;

        public CategoriesController(ICategories categories)
        {
            _categories = categories;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _categories.Index());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _categories.Details(id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categories/Create
        [Authorize(Policy = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategorieId,CategoryName,CategoryDescription")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                categorie = await _categories.Create(categorie);
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categories/Edit/5
        [Authorize(Policy = "Editor")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _categories.Edit(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,CategoryDescription")] Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categories.Edit(id, categorie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.Id))
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
            return View(categorie);
        }

        // GET: Categories/Delete/5
        [Authorize(Policy = "Administrator")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _categories.Delete(id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categories.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
            return  _categories.CategorieExists(id);
        }
    }
}
