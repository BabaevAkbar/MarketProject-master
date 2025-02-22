namespace Responses
{
    public class CategoryTreeResponseDto()
    {
        public Guid Id{ get; set; }
        public string? Name{ get; set; }
        public Guid? ParentId{ get; set; }
        public List<CategoryTreeResponseDto> SubCategories{ get; set; } = new List<CategoryTreeResponseDto>();
    }
}