using System;

namespace E_Commerce_App.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Items { get; set; }
        public double Total { get; set; }
        public DateTime dateTime { get; set; }
    }
}
