namespace Server.IOrderService
{
    public interface IOrderItemService
    {
        Task<List<int>> GetById();
        Task<List<int>> GetByUserId();
        
    }
}