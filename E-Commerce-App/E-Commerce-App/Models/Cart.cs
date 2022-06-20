using System.Collections.Generic;

namespace E_Commerce_App.Models
{
    public class Cart
    {
        int id { get; set; }

        public static List<Product> Products { get; set; }
        static Cart()
        {
            Products = new List<Product>();
        }
    }
}
