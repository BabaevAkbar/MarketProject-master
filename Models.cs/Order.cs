namespace MarketProject.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId{ get; set;}
        public DateTime CreateAt{ get; set; } = DateTime.UtcNow;
        public Status Status{ get; set;}

        public User? User{ get; set; }
        public List<OrderItem> OrderItem{ get; set; }
    }
}