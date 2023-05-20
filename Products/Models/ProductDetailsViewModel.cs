using App.Entities.Models;

namespace Products.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public List<Product> OtherProducts { get; set; }
    }
}
