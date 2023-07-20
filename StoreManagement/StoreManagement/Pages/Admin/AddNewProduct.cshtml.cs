using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreManagement.IService;
using StoreManagement.Models;
using System.Net.NetworkInformation;

namespace StoreManagement.Pages.Admin
{
    public class AddNewProductModel : PageModel
    {
        private readonly WebContext _context;
        private readonly ICategoryService _categoryService;

        public  AddNewProductModel(WebContext context, ICategoryService categoryService )
        {
            _context = context;
            _categoryService = categoryService;
             
        }
        public List<Category> categories { get; set; }
        public void OnGet()
        {
            categories = _categoryService.GetListCategories();

        }
    }
}
