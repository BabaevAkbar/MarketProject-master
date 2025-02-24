namespace Server.ICategoryService
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>>Get();
        Task<bool> Delete(Guid id);
        Task<CategoryResponseDto> Create(CreateCategoryRequest createCategoryRequest);
        Task<List<CategoryResponseDto>> Update(Guid Id,CreateCategoryRequest createCategoryRequest);
        Task<List<CategoryTreeResponseDto>> GetCategoryThreeAsync(Guid? parentId = null);

    }
}