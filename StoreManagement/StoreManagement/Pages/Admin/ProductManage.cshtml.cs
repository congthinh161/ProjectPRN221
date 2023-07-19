using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.IService;
using StoreManagement.Models;
using StoreManagement.Services;

namespace StoreManagement.Pages.Admin
{
    public class ProductManageModel : PageModel
    {
        private readonly WebContext _context;
        private readonly IProductService _productService;
        public ProductManageModel(WebContext context,IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public List<Product> products { get; set; }
        public void OnGet()
        {
            products = _productService.GetListProduct();
        }
    }
}
