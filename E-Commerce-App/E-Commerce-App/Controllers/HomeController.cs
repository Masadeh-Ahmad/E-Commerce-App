using E_Commerce_App.Data;
using E_Commerce_App.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.Controllers
{
    public class HomeController : Controller
    {
        private IEmail _email;
        private IOrderService _orderService;

        public HomeController(IEmail email, IOrderService orderService)
        {
            _orderService = orderService;
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
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminDash()
        {
            
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetOrders()
        {
            return View(await _orderService.GetOrders());
        }
    }
}
