using Geschäft.Domain.ProductAgg;

namespace Geschäft.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public DateTime CreationDate { get; set; }

        public ProductCategory(string name)
        {
            Name = name;
            Products = new List<Product>();
            CreationDate = DateTime.Now;
        }
        public void Edit(string name)
        {
            Name = name;
        }

    }
}
