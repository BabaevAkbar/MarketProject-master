namespace MarketProject.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Name { get; set; }
        public Guid? ParentCtegoryId{ get; set; }

        public List<Product> Products{ get; set; } = new List<Product>();
    }
}