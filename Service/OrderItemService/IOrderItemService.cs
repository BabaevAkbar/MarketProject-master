namespace Server.IOrderService
{
    public interface IOrderItemService
    {
        Task<List<int>> GetAll();
        Task<List<int>> Create();
        Task<List<int>> GetById();
        Task<List<int>> GetByUserId();
        
    }
}