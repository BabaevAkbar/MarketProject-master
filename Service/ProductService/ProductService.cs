namespace ProductServices.Server
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _product = new();
        public async Task<CreateProductResponse> Create(CreateProductRequest newProduct)
        {
            Product productRequest = new Product()
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price,
                CategoryId = newProduct.CategoryId
            };
            _product.Add(productRequest);
            
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
            int removeProduct = _product.RemoveAll(c => c.Id == id);
            if(removeProduct == 0)
                throw new Exception("Продукт не найден!");
            return true;
        }

        public async Task<List<CreateProductResponse>> GetFilteredProducts(ProductFilterRequest? request)
        {
            if(request == null)
            {
                var filteredProducts = _product.ToList();
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
                var filteredProducts = _product.Where(f => 
                (f.Name == request.Name || f.Price >= request.MinPrice || f.Price <= request.MaxPrice || f.CategoryId == request.ProductCategory)
                ).ToList();
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
            var updateProduct = _product.Where(p => p.Id == Id). ToList();
            return (CreateProductResponse)updateProduct.Select(p => new CreateProductResponse {Id = p.Id, Name = p.Name, Price = p.Price, CategoryId = p.CategoryId});
        }
    }
}