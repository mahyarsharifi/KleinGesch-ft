using Geschäft.Application.Contracts.Product;
using Geschäft.Application.Contracts.ProductCategory;

namespace Geschäft.Domain.ProductAgg
{
    public interface IProductRepository
    {
        void Create(Product product);
        void SaveChanges();
        EditProdcut GetDetails(int id);
        List<ProductViewModel> GetAll();
        Product Get(int id);
    }
}
