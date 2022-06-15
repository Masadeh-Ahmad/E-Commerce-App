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
        
       
        public IActionResult Index()
        {
       
            return View();
        }
        public IActionResult Aboutus()
        {

            return View();
        }
    }
}
