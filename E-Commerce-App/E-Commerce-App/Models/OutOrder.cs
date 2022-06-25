using System;
using System.Collections.Generic;

namespace E_Commerce_App.Models
{
    public class OutOrder
    {
        public int Id { get; set; }
        public string username { get; set; }
        public double Total { get; set; }
        public DateTime dateTime { get; set; }
        public List<Item> Item { get; set; }
        
    }
}
