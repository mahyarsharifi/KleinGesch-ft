using Geschäft.Application.Contracts.Product;
using Geschäft.Domain.ProductAgg;

namespace Geschäft.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(CreateProduct command)
        {
            var product = new Product(command.Name, command.UnitPrice, command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
        }

        public void Edit(EditProdcut command)
        {
            var product = _productRepository.Get(command.Id);
            if (product == null)
            {
                return;
            }
            product.Edit(command.Name, command.UnitPrice, command.CategoryId);
            _productRepository.SaveChanges();
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.GetAll();
        }

        public EditProdcut GetDetails(int id)
        {
            return _productRepository.GetDetails(id);
        }

        public void Remove(int id)
        {
            var product = _productRepository.Get(id);
            if (product == null)
            {
                return;
            }
            product.Remove();
            _productRepository.SaveChanges();
        }

        public void Restore(int id)
        {
            var product = _productRepository.Get(id);
            if (product != null)
            {
                product.Restore();
            }
            else
            {
                return;
            }
            _productRepository.SaveChanges();
        }
    }
}
