namespace ProductServices.Server
{
    public class ProductService : IProductService
    {
        private readonly MarketProjectDbContext _context;

        public ProductService(MarketProjectDbContext context)
        {
            _context = context;
        }
        public async Task<CreateProductResponse> Create(CreateProductRequest newProduct)
        {
            var categoryExists = await _context.Category.AnyAsync(c => c.Id == newProduct.CategoryId);
            if (!categoryExists)
            {
                throw new Exception($"Категория с ID {newProduct.CategoryId} не существует.");
            }
            Product productRequest = new Product()
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price,
                CategoryId = newProduct.CategoryId
            };
            await _context.Product.AddAsync(productRequest);
            await _context.SaveChangesAsync();
            
            CreateProductResponse productResponse = new CreateProductResponse()
            {
                Id = productRequest.Id,
                Name = productRequest.Name,
                Price = productRequest.Price,
                CategoryId = productRequest.CategoryId
            };
            return productResponse;
        }

        public async Task<bool> Delete(Guid id)
        {
            var removeProduct = await _context.Product.FindAsync(id);
            if(removeProduct != null)
            {
                _context.Product.Remove(removeProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Категория не найдено!");
            }
        }

        public async Task<List<CreateProductResponse>> GetFilteredProducts(ProductFilterRequest? request)
        {
            if(request.Name == null && request.MaxPrice == null && request.MinPrice == null && request.ProductCategory == null)
            {
                var filteredProducts = await _context.Product.ToListAsync();
                var result = filteredProducts.Select(p => new CreateProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId
                    
                }).ToList();
                return result;
                
            }
            else
            {
                var filteredProducts = await _context.Product.Where(f => 
                (f.Name == request.Name || f.Price >= request.MinPrice || f.Price <= request.MaxPrice || f.CategoryId == request.ProductCategory)
                ).ToListAsync();
                var result = filteredProducts.Select(p => new CreateProductResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryId = p.CategoryId
                }).ToList();

                return result;
            }
        }

        public async Task<CreateProductResponse> Update(Guid Id, CreateProductRequest createProduct)
        {
            var updateProduct = await Task.Run(() => _context.Product.Where(p => p.Id == Id));
            var result = updateProduct.Select(p => new CreateProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId
            });
            return (CreateProductResponse)result;
        }
    }
}