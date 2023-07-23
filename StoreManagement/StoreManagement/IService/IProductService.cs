using StoreManagement.Models;

namespace StoreManagement.IService
{
    public interface IProductService
    {
        public List<Product> GetListProduct();
        public Product GetProductByPid(string pid);
        public List<Product> GetListProductPaging(int skip);
        public int CountAllProduct();
        public int CountProductsByCategory(int cateId);
        public void AddNewProduct(Product product);
        public int RemoveProduct(string pId);
        public int UpdateProduct(Product product);
        public dynamic BestSellProduct(int take);
        public List<Product> SearchByCategoryPaging(int id, int skip);
        public int CountAllProductsByCateId(int cateId);

    }
}
