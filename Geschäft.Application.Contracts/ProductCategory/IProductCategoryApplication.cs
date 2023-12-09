namespace Geschäft.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);
        EditProductCategory GetDetails(int id);
        List<ProductCategoryViewModel> GetAll();
    }
}
