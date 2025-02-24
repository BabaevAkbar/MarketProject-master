namespace Responses
{
    public class CategoryResponseDto
    {
        public Guid Id{ get; set; }
        public string? Name {  get; set; }
        public Guid? ParentCategoryId { get; set; } = new();
    }
}