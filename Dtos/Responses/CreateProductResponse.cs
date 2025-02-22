namespace Responses
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price{ get; set; }
        public Guid CategoryId{ get; set; }
    }
}