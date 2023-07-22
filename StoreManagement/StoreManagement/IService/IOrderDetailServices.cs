using StoreManagement.Models;

namespace StoreManagement.IService
{
    public interface IOrderDetailServices
    {
        public List<Order> GetOrderByUname(string uname);
        public List<OrderDetail> GetOrderDetailsByOId(int oid);

    }
}
