using CS_RestApi.DAL.Entities;
using CS_RestApi.Exceptions;
using CS_RestApi.Utils;

namespace CS_RestApi.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private AzureContext _context;
        public OrderRepository(AzureContext context)
        {
            _context = context;
        }
        public async Task<int> CreateNewOrderAsync(Order order)
        {
            try
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return order.OrderNumber;
            }
            catch(Exception e)
            {
                throw;
            }
            
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }
    }
}
