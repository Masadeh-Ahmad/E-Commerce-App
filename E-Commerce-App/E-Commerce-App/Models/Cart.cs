using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Models
{
    public class Cart
    {

        public int Id { get; set; }
        public string userame { get; set; }

        public static List<Product> Products { get; set; }
        public Cart()
        {
            Products = new List<Product>();
        }

    }
}
