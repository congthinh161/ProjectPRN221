using StoreManagement.Models;

namespace StoreManagement.IService
{
    public interface IOrderServices
    {
        public List<Order> GetAllOrders();
        public List<Order> GetTopValueOrder(int take);
    }
}
