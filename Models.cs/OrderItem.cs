namespace MarketProject.Models
{
    public class OrderItem
    {
        public Guid Id{ set; get; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Guid ProductId{ get; set;}
        public int Quantity{ get; set; }
        public int TotalPrice{ get; set; }

        public Order Order{ get; set; }
        public Product Product{ get; set; }

    }
}