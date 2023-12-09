using Geschäft.Application.Contracts.Product;
using Geschäft.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KleinGeschäft.Pages.Product
{
    public class EditModel : PageModel
    {
        public EditProdcut Command;
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public EditModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(int id)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetAll(), "Id", "Name");
            Command = _productApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost(EditProdcut product)
        {
            _productApplication.Edit(product);
            return RedirectToPage("/Index");
        }
    }
}
