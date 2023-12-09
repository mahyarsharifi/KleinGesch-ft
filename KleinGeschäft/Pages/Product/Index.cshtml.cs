using Geschäft.Application.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KleinGeschäft.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> Products;
        private readonly IProductApplication _productApplication;
        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        public void OnGet()
        {
            Products = _productApplication.GetAll();
        }
    }
}
