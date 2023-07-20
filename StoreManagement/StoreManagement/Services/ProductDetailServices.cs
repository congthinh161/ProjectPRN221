using StoreManagement.IService;
using StoreManagement.Models;

namespace StoreManagement.Services
{
    public class ProductDetailServices : IProductDetailService
    {
        private readonly WebContext _context;
        public ProductDetailServices(WebContext context)
        {
            _context = context;
        }
        public void AddProductDetails(ProductDetail productDetail)
        {
            _context.Add(productDetail);
            _context.SaveChanges();
        }
    }
}
