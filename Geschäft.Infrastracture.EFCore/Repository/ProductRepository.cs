using Geschäft.Application.Contracts.Product;
using Geschäft.Application.Contracts.ProductCategory;
using Geschäft.Domain.ProductAgg;

namespace Geschäft.Infrastracture.EFCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly GeschäftContext _context;
        public ProductRepository(GeschäftContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);

        }

        public List<ProductViewModel> GetAll()
        {
            return _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                CreationDate = x.CreationDate.ToString(),
                Category = x.ProductCategory.Name
            }).ToList();
        }

        public EditProdcut GetDetails(int id)
        {
            return _context.Products.Select(x => new EditProdcut
            {
                Id = x.Id,
                Name = x.Name,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
