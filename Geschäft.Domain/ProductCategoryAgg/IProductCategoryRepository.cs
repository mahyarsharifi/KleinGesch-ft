using Geschäft.Application.Contracts.ProductCategory;

namespace Geschäft.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory category);
        void SaveChanges();
        List<ProductCategoryViewModel> GetAll();
        ProductCategory Get(int id);
        EditProductCategory GetDetails(int id);
    }
}
