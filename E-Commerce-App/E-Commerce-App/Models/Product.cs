namespace E_Commerce_App.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int price { get; set; }
        public string Description { get; set; }
        public bool stock { get; set; }
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
