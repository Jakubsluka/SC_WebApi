namespace CS_RestApi.Domain
{
    public class PaymentInfoRequest
    {
        public int OrderNumber { get; set; }
        public bool Paid { get; set; }
    }
}
