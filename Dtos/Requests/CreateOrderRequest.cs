namespace Requests
{
    public class CreateOrderRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId{ get; set; }
        public DateTime TimeCreate{ get; set; }
        public Status Status{ get; set; }
        public List<OrderItem> OrderItems{ get; set; }
    }
}