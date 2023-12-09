using Geschäft.Application.Contracts.ProductCategory;

namespace Geschäft.Application.Contracts.Product
{
    public interface IProductApplication
    {
        void Create(CreateProduct command);
        void Edit(EditProdcut command);
        void Remove(int id);
        void Restore(int id);
        EditProdcut GetDetails(int id);
        List<ProductViewModel> GetAll();
    }
}
