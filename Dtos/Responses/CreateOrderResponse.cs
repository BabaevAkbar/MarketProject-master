namespace Responses
{
    public class CreateOrderResponse
    {
        public Guid Id{ get; set; }
        public Status Status{ get; set; }
        public DateTime TimeCreate{ get; set; }
    }
}