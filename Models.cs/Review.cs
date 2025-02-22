namespace MarketProject.Models
{
    public class Review
    {
        public Guid Id{ get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid ProductId{ get; set; }
        public int Rating{ get; set; }
        public string? Comment{ get; set; }

        public User? User{ get; set;}
        public Product? Product{ get; set; }
    }
}