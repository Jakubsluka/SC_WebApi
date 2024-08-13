using CS_RestApi.Utils;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_RestApi.DAL.Entities
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string OrderCustomerName { get; set; } = string.Empty;
        public DateTime OrderCreatedDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
