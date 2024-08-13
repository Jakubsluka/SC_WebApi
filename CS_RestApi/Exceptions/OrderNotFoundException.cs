namespace CS_RestApi.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public int OrderNumber { get; private set; }
        public OrderNotFoundException(string text, int orderNumber) : base(text) 
        {
            this.OrderNumber = orderNumber;
        }

        public override string ToString()
        {
            return $"{Message}, OrderNumber: {OrderNumber}";
        }
    }
}
