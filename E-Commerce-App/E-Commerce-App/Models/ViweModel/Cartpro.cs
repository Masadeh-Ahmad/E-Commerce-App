using System.Collections.Generic;

namespace E_Commerce_App.Models.ViweModel
{
    public  class Cartpro
    {
        public static List<Product> Products { get; set; }
         static Cartpro()
        {
            Products = new List<Product>();
        }
    }
}
