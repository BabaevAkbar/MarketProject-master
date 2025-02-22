namespace Requests
{
    public class CreateProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price{ get; set; }
        public Guid CategoryId{ get; set; }
    }
}