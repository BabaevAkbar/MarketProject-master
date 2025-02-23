namespace Server.IProductServise
{
    public interface IProductService
    {
        Task<List<CreateProductResponse>> GetFilteredProducts(ProductFilterRequest request);
        Task<bool> Delete(Guid id);
        Task<CreateProductResponse> Create(CreateProductRequest newProduct);
        Task<CreateProductResponse> Update(Guid Id, CreateProductRequest createProduct);

    }
}