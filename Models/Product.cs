using System.ComponentModel.DataAnnotations;

namespace LearnMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Product Quantitiy")]
        public int Quantity { get; set; }

        [Display(Name = "Product Price")] 
        public decimal Price { get; set; }

        [Display(Name = "Available")] 
        public bool InStock { get; set; }

        [Display(Name = "Publish")] 
        public bool InPublish { get; set; }
    }
}
