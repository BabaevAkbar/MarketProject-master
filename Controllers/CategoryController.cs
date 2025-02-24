namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var categories = await _CategoryService.Get();
            return Ok(new ApiResponse<List<CategoryResponseDto>>(categories, "Список категорий"));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var categories = await _CategoryService.Delete(Id);
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCategoryRequest createCategoryRequest)
        {
            var category = await _CategoryService.Create(createCategoryRequest);
            return Ok(category);
        }
    }
}