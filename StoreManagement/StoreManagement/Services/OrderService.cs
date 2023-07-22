using StoreManagement.IService;
using StoreManagement.Models;

namespace StoreManagement.Services
{
    public class OrderService : IOrderServices
    {
        private readonly WebContext _context;


        public OrderService(WebContext context)
        {
            _context = context;
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public List<Order> GetTopValueOrder(int take)
        {
            return _context.Orders.OrderByDescending(x => x.Total).Take(take).ToList();
        }
    }
}
