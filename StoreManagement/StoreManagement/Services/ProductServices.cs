using StoreManagement.IService;
using StoreManagement.Models;

namespace StoreManagement.Services
{
    public class ProductServices : IProductService
    {
        private readonly WebContext _context;
        private readonly IConfiguration _config;
        public ProductServices(WebContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }


        public List<Product> GetListProduct()
        {
            return _context.Products.ToList();
        }
    }
}
