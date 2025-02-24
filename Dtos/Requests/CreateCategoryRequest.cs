namespace Requests
{
    public class CreateCategoryRequest
    {
        [Required]
        public string? Name { get; set; }
        public Guid? ParentCategoryId{ get; set; }
    }
}