using Geschäft.Application.Contracts.ProductCategory;
using Geschäft.Infrastracture.EFCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KleinGeschäft.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            ProductCategories = _productCategoryApplication.GetAll();
        }
    }
}
