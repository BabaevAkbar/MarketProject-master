namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetFilterPRoducts([FromQuery]ProductFilterRequest? request)
        {
            var products = await _service.GetFilteredProducts(request);
            return Ok(products);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest createProduct)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>("Ошибка валидации данных."));
            }
            var product = await _service.Create(createProduct);
            return Ok(new ApiResponse<CreateProductResponse>(product, "Продукт успешно создан."));
        }
        
    }
}