namespace MarketProject.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public Guid? ParentCategoryId{ get; set; }
        public List<Category> SubCategories { get; set; } = new List<Category>();

        public List<Product> Products{ get; set; } = new List<Product>();
    }
}