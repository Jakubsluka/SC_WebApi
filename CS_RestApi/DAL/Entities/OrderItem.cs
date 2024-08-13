using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_RestApi.DAL.Entities
{
    public class OrderItem 
    {
        public Guid OrderItemId { get; set; }
        public int OrderNumber { get; set; }
        public string OrderItemName { get; set; } = string.Empty;
        public int OrderItemAmount { get; set; }
        public double OrderItemSinglePrice { get; set; }
        public Order Order { get; set; }
    }
}
