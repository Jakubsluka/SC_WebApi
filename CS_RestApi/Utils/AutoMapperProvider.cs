using CS_RestApi.DAL.Entities;
using CS_RestApi.Domain;

namespace CS_RestApi.Utils
{
    public static class MapHelper
    {
        public static Order MapCreateOrderRequestToOrder(CreateOrderRequest request) 
        {
            var output = new Order()
            {
                OrderCreatedDate = DateTime.Now,
                OrderCustomerName = request.CustomerName,
                OrderStatus = OrderStatusEnum.New,

                OrderItems = request.OrderItems.Select(o => new OrderItem()
                {
                    OrderItemId = Guid.NewGuid(),
                    OrderItemAmount = o.ItemAmount,
                    OrderItemName = o.ItemName,
                    OrderItemSinglePrice = o.ItemSoloPrice,

                }).ToList()
            };

            return output;
        }
    }
}
