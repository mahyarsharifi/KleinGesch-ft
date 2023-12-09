using Geschäft.Application.Contracts.ProductCategory;
using Geschäft.Infrastracture.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KleinGeschäft.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        public EditProductCategory Command;
        private readonly GeschäftContext _context;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public EditModel(IProductCategoryApplication productCategoryApplication, GeschäftContext context)
        {
            _productCategoryApplication = productCategoryApplication;
            _context = context;
        }
        public void OnGet(int id)
        {
            Command = _productCategoryApplication.GetDetails(id);
        }
        public RedirectToPageResult OnPost(EditProductCategory productCategory)
        {
            _productCategoryApplication.Edit(productCategory);
            return RedirectToPage("./Index");
        }
    }
}
