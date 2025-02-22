namespace Requests
{
    public class CreateCategoryRequest
    {
        [Required]
        public string? Name { get; set; }
    }
}