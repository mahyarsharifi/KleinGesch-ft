using Geschäft.Application.Contracts.ProductCategory;
using Geschäft.Domain.ProductCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Geschäft.Infrastracture.EFCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly GeschäftContext _context;

        public ProductCategoryRepository(GeschäftContext context)
        {
            _context = context;
        }

        public void Create(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            SaveChanges();
        }

        public ProductCategory Get(int id)
        {
            return _context.ProductCategories.FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString()
            }).ToList();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault(x => x.Id == id);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

