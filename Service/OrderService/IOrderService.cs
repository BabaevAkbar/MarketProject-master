namespace Server.IOrderService
{
    interface IOrderService
    {
        Task<List<CreateOrderResponse>> GetAll();
        Task<CreateOrderResponse> GetById(Guid Id);
        Task<List<CreateOrderResponse>> GetByStatus(Status status);
        Task<List<CreateOrderResponse>> GetByDateTime(DateTime dateTime);

        Task<CreateOrderResponse> Create(CreateOrderRequest createOrder);
        Task<CreateOrderResponse> Update(Guid Id, CreateOrderRequest createOrder);
        Task<bool> Delete(Guid Id);
    }
}