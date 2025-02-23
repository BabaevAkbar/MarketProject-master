namespace ProductWebApi.Server
{
    public class CategoryService : ICtegoryService
    {
        private readonly MarketProjectDbContext _context;

        public CategoryService(MarketProjectDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryResponseDto> Create(CreateCategoryRequest createCategoryRequest)
        {
            Category category = new Category()
            {
                Name = createCategoryRequest.Name,
            };
            await _context.SaveChangesAsync();
            CategoryResponseDto categoryResponseDto = new CategoryResponseDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryResponseDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var removeCategory = await _context.Category.FindAsync(id);
            if(removeCategory != null)
            {
                _context.Category.Remove(removeCategory);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Категория не найдено!");
            }
        }


    // public async Task<List<Category>> GetChild(Guid pId)
    // {
    //     var categories = await _context.Category.Where(c => c.ParentCtegoryId == pId).ToListAsync();
    //     /*
    //     var categories = _categories.Select(u => new Category{Id = u.Id, Name=u.Name, ParentCtegoryId = u.ParentCtegoryId}).ToList();
    //     var categoryMap = categories.ToDictionary(
    //         c => c.Id,
    //         c => new CategoryResponseDto { Id = c.Id, Name = c.Name }
    //     );

    //     List<CategoryResponseDto> rootNodes = new();

    //     foreach (var category in categories)
    //     {
    //         if (category.ParentCtegoryId != null)
    //         {
    //             categoryMap[category.ParentCtegoryId].Children.Add(categoryMap[category.Id]);
    //         }
    //         else
    //         {
    //             rootNodes.Add(categoryMap[category.Id]);
    //         }
    //     }

    //     return rootNodes;
    //     */
    //     throw new NotImplementedException(); 
    // }

        public async Task<List<CategoryResponseDto>> Update(Guid Id, CreateCategoryRequest createCategoryRequest)
        {
            var updateCategory = await _context.Category.Where(c => c.Id == Id).ToListAsync();
            return updateCategory.Select(c => new CategoryResponseDto { Id = c.Id, Name = c.Name }).ToList();
            
        }

        public async Task<List<CategoryResponseDto>?> GetAll()
        {
            var allCategory = await _context.Category.ToListAsync();

            var categoryResponse = allCategory.Select(p => new CategoryResponseDto { Id = p.Id, Name = p.Name }).ToList();
            return categoryResponse;
        }

        public async Task<List<CategoryTreeResponseDto>> GetCategoryThreeAsync(Guid? parentId = null)
        {
            if(parentId.HasValue)
            {
                var getCategory = 
                await Task.Run(() => _context.Category.Where(c => c.ParentCtegoryId == parentId));
            }
            else
            {
                var getCategory = await Task.Run(() => _context.Category.Where(c => c.ParentCtegoryId == null));
            }

            var categories = await _context.Category.Select(c => new CategoryTreeResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentCtegoryId
            }).ToListAsync();

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