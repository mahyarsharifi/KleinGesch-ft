using Geschäft.Application.Contracts.ProductCategory;
using Geschäft.Domain.ProductCategoryAgg;

namespace Geschäft.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public void Create(CreateProductCategory command)
        {
            var productCategpry = new ProductCategory(command.Name);
            _productCategoryRepository.Create(productCategpry);
            _productCategoryRepository.SaveChanges();
        }

        public void Edit(EditProductCategory command)
        {
            var productCategpry = _productCategoryRepository.Get(command.Id);
            if (productCategpry == null)
            {
                return;
            }
            productCategpry.Edit(command.Name);
            _productCategoryRepository.SaveChanges();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public EditProductCategory GetDetails(int id)
        {
            return _productCategoryRepository.GetDetails(id);
        }
    }
}
