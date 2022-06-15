using System.Collections.Generic;

namespace E_Commerce_App.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Product> Products { get; set; }

    }
}
