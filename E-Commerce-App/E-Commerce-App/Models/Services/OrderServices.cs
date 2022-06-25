using E_Commerce_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using E_Commerce_App.Models.Interface;
using Newtonsoft.Json;

namespace E_Commerce_App.Models.Services
{
    public class OrderServices : IOrderService
    {
        private readonly EcommercelDbContext _db;
        public OrderServices(EcommercelDbContext db)
        {
            _db = db;
        }
        public async Task<List<OutOrder>> GetOrders()
        {
            
            var orders = await _db.Orders.ToListAsync();
            return orders.Select(x => new OutOrder
            {
                Id = x.Id,
                dateTime = x.dateTime,
                Total = x.Total,
                username = x.username,
                Item = JsonConvert.DeserializeObject<List<Item>>(x.Items)
            }).ToList();
          
        }
    }
}
