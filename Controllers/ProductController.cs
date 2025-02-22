namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly MarketProjectDbContext _context;

        public ProductController(MarketProjectDbContext context)
        {
            _context = context;
        }

        // [HttpGet("filter")]
        // public async Task<IActionResult> GetFilterProduct([FromBody] ProductFilterRequest fileRequest)
        // {
        //     var product = await _productService.GetAll();
        //     ApiResponse<List<CreateProductResponse>> result = new ApiResponse<List<CreateProductResponse>>(product, "Фильтарция успешно выполнена.");
        //     return (IActionResult)result;
        // }

        // [HttpGet("filter")]
        // public async Task<ActionResult<ApiResponse<CreateProductResponse>>> GetFilterProduct(ProductFilterRequest fileRequest)
        // {
        //     var productss = await _context.Product
        //         .Include(a => a.Category);
        //     var products = await _context.(fileRequest);
        //     var result = new ApiResponse<List<CreateProductResponse>>(products, "Фильтрация успешно выполнена.");
        //     return Ok(result);
        // }

        // [HttpPost]
        // public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createProduct)
        // {
        //     if(!ModelState.IsValid)
        //     {
        //         return BadRequest(new ApiResponse<string>("Ошибка валидации данных."));
        //     }
        //     var product = await _context.Create(createProduct);
        //     return CreatedAtAction(nameof(GetFilterProduct), null, new ApiResponse<CreateProductResponse>(product, "Продукт успешно создан."));
        // }
    }
}