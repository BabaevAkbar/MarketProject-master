namespace Server.ICtegoryService
{
    interface ICtegoryService
    {
        Task<List<CategoryResponseDto>>GetAll();
        Task<List<Category>>GetChild(int pId);
        Task<bool> Delete(Guid id);
        Task<CategoryResponseDto> Create(CreateCategoryRequest createCategoryRequest);
        Task<List<CategoryResponseDto>> Update(Guid Id,CreateCategoryRequest createCategoryRequest);
        Task<List<CategoryTreeResponseDto>> GetCategoryThreeAsync(Guid? parentId = null);

    }
}