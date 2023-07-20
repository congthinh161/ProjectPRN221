using StoreManagement.IService;
using StoreManagement.Models;
using System.Security.Cryptography;

namespace StoreManagement.Services
{
    public class ProductServices : IProductService
    {
        private readonly WebContext _context;
        private readonly IConfiguration _config;
        public int paging { get; set; } 
        public ProductServices(WebContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            //paging  = Convert.ToInt32(_config.GetSection("PageSettings")["Paging"]);
        }

        public List<Product> GetListProduct()
        {
            return _context.Products.ToList();
        }
        public List<Product> GetListProductPaging(int skip)
        {
            paging = Convert.ToInt32(_config.GetSection("PageSettings")["Paging"]);
            return _context.Products.Skip(skip * paging).Take(paging).ToList(); 
        }

        public int CountAllProduct()
        {
            return GetListProduct().Count;
        }

        public int CountProductsByCategory(int cateId)
        {
            if (cateId == 0)
            {
                return _context.Products.ToList().Count;
            }
            else
            {
                return _context.Products.Where(x => x.Cid == cateId).ToList().Count;
            }
        }

        public int RemoveProduct(string pId)
        {
            Product product = _context.Products.Where(x => x.Pid.Equals(pId)).FirstOrDefault();
            ProductDetail productDetail = _context.ProductDetails.Where(x => x.Pid.Equals(pId)).FirstOrDefault();
            List<StorageDetail> storageDetail = _context.StorageDetails.Where(x => x.Pid.Equals(pId)).ToList();
            List<ColorDetail> colorDetail = _context.ColorDetails.Where(x => x.Pid.Equals(pId)).ToList();
            try
            {
                if (productDetail != null)
                {
                    _context.ProductDetails.Remove(productDetail);
                }

                if (storageDetail != null && storageDetail.Count > 0)
                {
                    _context.StorageDetails.RemoveRange(storageDetail);
                }

                if (colorDetail != null && colorDetail.Count > 0)
                {
                    _context.ColorDetails.RemoveRange(colorDetail);
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}
