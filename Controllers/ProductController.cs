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
        public async Task<IActionResult> GetFilterPRoducts([FromBody]ProductFilterRequest? request)
        {
            try
            {
                var products = await _service.GetFilteredProducts(request);
                return Ok(new ApiResponse<CreateProductResponse>(products, "Пользователь успешно зарегистрирован"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ApiResponse<CreateProductResponse>>> GetFilterProduct(ProductFilterRequest fileRequest)
        {
            
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest createProduct)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>("Ошибка валидации данных."));
            }
            var product = await _context.Create(createProduct);
            return CreatedAtAction(nameof(GetFilterProduct), null, new ApiResponse<CreateProductResponse>(product, "Продукт успешно создан."));
        }/ public async Task<IActionResult> GetFilterProduct([FromBody] ProductFilterRequest fileRequest)
        
    }
}