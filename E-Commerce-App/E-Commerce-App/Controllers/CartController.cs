using E_Commerce_App.Models;
using E_Commerce_App.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using E_Commerce_App.Data;
using SendGrid;
using SendGrid.Helpers.Mail;
using E_Commerce_App.Auth.Interfaces;
using System;

namespace E_Commerce_App.Controllers
{
    public class CartController : Controller
    {
        private readonly IProducts _product;
        private readonly IUserService _userService;
        private readonly EcommercelDbContext _db;
        public CartController(IProducts product, EcommercelDbContext db, IUserService userService)
        {
            _product= product;
            _db= db;
            _userService= userService;
        }
       

        public async Task<IActionResult> addCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart == null)
            {
                var product = await _product.Details(id);
                List<Item> listCart = new List<Item>()
               {
                   new Item
                   {
                       Product = product,
                       Quantity = 1
                   }
               };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

            }
            else
            {
                List<Item> dataCart = JsonConvert.DeserializeObject<List<Item>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.Id == id)
                    {
                        dataCart[i].Quantity++;
                        check = false;
                    }
                }
                if (check)
                {
                    dataCart.Add(new Item
                    {
                        Product = await _product.Details(id),
                    Quantity = 1
                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));

            }

            return Redirect("/Products/index");

        }
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetString("cart");
            List<Item> dataCart = null;
            if(cart != null)
            {
                dataCart = JsonConvert.DeserializeObject<List<Item>>(cart);
            }

            return View(dataCart);
        }
        [HttpPost]
        public IActionResult updateCart(int id, int quantity)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Item> dataCart = JsonConvert.DeserializeObject<List<Item>>(cart);
                if (quantity > 0)
                {
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        if (dataCart[i].Product.Id == id)
                        {
                            dataCart[i].Quantity = quantity;
                        }
                    }


                    HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                }
                var cart2 = HttpContext.Session.GetString("cart");
                return Ok(quantity);
            }
            return BadRequest();

        }
        public IActionResult deleteCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Item> dataCart = JsonConvert.DeserializeObject<List<Item>>(cart);

                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Product.Id == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Order(string username)
        {
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<Item> dataCart = JsonConvert.DeserializeObject<List<Item>>(cart);
                int total = 0;
                foreach(Item item in dataCart)
                {
                    total += item.Product.price * item.Quantity;
                }
                var order = new Order { username = User.Identity.Name, Items = cart ,Total=total,dateTime=DateTime.Now.ToLocalTime() };
                _db.Add(order);
                await _db.SaveChangesAsync();
                SendGridClient client = new SendGridClient("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");
                SendGridMessage msg = new SendGridMessage();
                msg.SetFrom("22029729@student.ltuc.com", "ASAC Team");
                msg.AddTo(await _userService.GetEmail(User));
                msg.SetSubject("Confirmation Order");
                msg.AddContent(MimeType.Html, $"Your Order with ID_Number {order.Id} has been confirmed");
                await client.SendEmailAsync(msg);
            }
            HttpContext.Session.Clear();
            return Redirect("/Products/index");
        }
    }
}
