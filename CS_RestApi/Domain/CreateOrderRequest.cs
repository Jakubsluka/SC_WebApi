namespace CS_RestApi.Domain
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public List<CreateOrderRequestOrderItem> OrderItems { get; set; }
    }

    public class CreateOrderRequestOrderItem 
    {
        public string ItemName { get; set; }
        public int ItemAmount { get; set; } 
        public double ItemSoloPrice { get; set; }
    }
}
