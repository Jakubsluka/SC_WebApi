using CS_RestApi.DAL.Entities;
using CS_RestApi.Utils;

namespace CS_RestApi.DAL.Repositories
{
    public interface IOrderRepository
    {
        Task<int> CreateNewOrderAsync(Order order);
        IEnumerable<Order> GetOrders();
    }
}