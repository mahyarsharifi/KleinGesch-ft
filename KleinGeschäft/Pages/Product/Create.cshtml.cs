using Geschäft.Application.Contracts.Product;
using Geschäft.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KleinGeschäft.Pages.Product
{
    public class CreateModel : PageModel
    {
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetAll(), "Id", "Name");
        }
        public RedirectToPageResult OnPost(CreateProduct command)
        {
            _productApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
