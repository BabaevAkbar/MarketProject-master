namespace ProductWebApi.Server
{
    public class CategoryService : ICtegoryService
    {
        private readonly List<Category> _categories = new();

        public async Task<CategoryResponseDto> Create(CreateCategoryRequest createCategoryRequest)
        {
            Category category = new Category()
            {
                Name = createCategoryRequest.Name,
            };
            _categories.Add(category);
            CategoryResponseDto categoryResponseDto = new CategoryResponseDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryResponseDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            int removeCategory = _categories.RemoveAll(c => c.Id == id);
            if(removeCategory == 0)
                throw new Exception("Категория не найдено!");
            return true;
        }


    public async Task<List<Category>> GetChild(int pId)
    {
        /*
        var categories = _categories.Select(u => new Category{Id = u.Id, Name=u.Name, ParentCtegoryId = u.ParentCtegoryId}).ToList();
        var categoryMap = categories.ToDictionary(
            c => c.Id,
            c => new CategoryResponseDto { Id = c.Id, Name = c.Name }
        );

        List<CategoryResponseDto> rootNodes = new();

        foreach (var category in categories)
        {
            if (category.ParentCtegoryId != null)
            {
                categoryMap[category.ParentCtegoryId].Children.Add(categoryMap[category.Id]);
            }
            else
            {
                rootNodes.Add(categoryMap[category.Id]);
            }
        }

        return rootNodes;
        */
        throw new NotImplementedException(); 
    }

        public async Task<List<CategoryResponseDto>> Update(Guid Id, CreateCategoryRequest createCategoryRequest)
        {
            var updateCategory = _categories.Where(c => c.Id == Id).ToList();
            return updateCategory.Select(c => new CategoryResponseDto { Id = c.Id, Name = c.Name }).ToList();
            
        }

        public async Task<List<CategoryResponseDto>?> GetAll()
        {
            var allCategory = _categories.ToList();

            var categoryResponse = allCategory.Select(p => new CategoryResponseDto { Id = p.Id, Name = p.Name }).ToList();
            return categoryResponse;
        }

        public async Task<List<CategoryTreeResponseDto>> GetCategoryThreeAsync(Guid? parentId = null)
        {
            var allCategory = _categories.ToList();
            if(parentId.HasValue)
            {
                var getCategory = _categories.Where(c => c.ParentCtegoryId == parentId);
            }
            else
            {
                var getCategory = _categories.Where(c => c.ParentCtegoryId == null);
            }

            var categories = _categories.Select(c => new CategoryTreeResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentCtegoryId
            }).ToList();

            var lookUp = categories.ToDictionary(c => c.Id);

            var result = new List<CategoryTreeResponseDto>();
            foreach (var category in categories)
            {
                if (category.ParentId == null || (parentId.HasValue && category.ParentId == parentId))
                {
                    result.Add(category);
                }
                else if(lookUp.ContainsKey(category.ParentId.Value))
                {
                    lookUp[category.ParentId.Value].SubCategories.Add(category);
                }
            }

            return result;
        }

        
    }
}