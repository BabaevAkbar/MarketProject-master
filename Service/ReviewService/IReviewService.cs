namespace Server.IReviewService
{
    public interface IReviewService
    {
        Task<ReviewResponse> Ctreate(ReviewRequest reviewRequest);
        Task<bool> Delete(Guid Id);
        Task<ReviewResponse> Update(ReviewRequest reviewRequest);
        Task<List<ReviewResponse>> GetProductReview(Guid ProductId);
        Task<List<ReviewResponse>> GetUserReview(Guid UserId);        
    }
}