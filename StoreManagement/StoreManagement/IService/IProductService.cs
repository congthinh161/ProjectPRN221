using StoreManagement.Models;

namespace StoreManagement.IService
{
    public interface IProductService
    {
        public List<Product> GetListProduct();
        public List<Product> GetListProductPaging(int skip);
        public int CountAllProduct();
        public int CountProductsByCategory(int cateId);
        public void AddNewProduct(Product product);
        public int RemoveProduct(string pId);

    }
}
