namespace Server.IReviewService
{
    public interface IReviewService
    {
        Task<List<int>> Ctreate();
        Task<int> Delete();
        Task<int> Update();
        Task<List<int>> GetProductId();
        
    }
}