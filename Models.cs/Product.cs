namespace MarketProject.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price{ get; set; }
        public Guid CategoryId{ get; set; }
        public List<Review> Reviews { get; set; } = new();

        public Category Category{ get; set; }
    }
}