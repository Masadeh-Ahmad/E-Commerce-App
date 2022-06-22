using E_Commerce_App.Models.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E_Commerce_App.Controllers
{
    public class HomeController : Controller
    {
        private IEmail _email;
        public HomeController(IEmail email)
        {
            _email = email;
        }
       
        public IActionResult Index()
        {
       
            return View();
        }
        public IActionResult Aboutus()
        {

            return View();
        }
        public IActionResult sendEmail()
        {
            _email.sendEmail();
            return RedirectToAction(nameof(Index));
        }
    }
}
