namespace ReviewService.Server
{
    public class ReviewService : IReviewService
    {
        private readonly MarketProjectDbContext _context;
        public ReviewService(MarketProjectDbContext context)
        {
            _context = context;
        }
        public async Task<ReviewResponse> Ctreate(ReviewRequest reviewRequest)
        {
            Review review = new Review
            {
                Id = reviewRequest.Id,
                UserId = reviewRequest.UserId,
                ProductId = reviewRequest.ProductId,
                Comment = reviewRequest.Content,
                Rating = reviewRequest.Rating
            };
            await _context.SaveChangesAsync();
            ReviewResponse reviewResponse = new ReviewResponse
            {
                Id = review.Id,
                UserId = review.UserId,
                ProductId = review.ProductId,
                Content = review.Comment,
                Rating = review.Rating,
                Time = review.Time
            };
            return reviewResponse;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var review = await _context.Review.FindAsync(Id);
            if (review != null)
            {
                _context.Review.Remove(review);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Комметария не найдена!");
            }
        }

        public async Task<List<ReviewResponse>> GetProductReview(Guid ProductId)
        {
            var review = await _context.Review.Where(r => r.ProductId == ProductId).ToListAsync();
            var reviewResponse = review.Select(r => new ReviewResponse
            {
                Id = r.Id,
                UserId = r.UserId,
                ProductId = r.ProductId,
                Content = r.Comment,
                Rating = r.Rating,
                Time = r.Time
            }).ToList();
            return reviewResponse;
        }

        public async Task<List<ReviewResponse>> GetUserReview(Guid UserId)
        {
            var review = await _context.Review.Where(r => r.UserId == UserId).ToListAsync();
            var reviewResponse = review.Select(r => new ReviewResponse
            {
                Id = r.Id,
                UserId = r.UserId,
                ProductId = r.ProductId,
                Content = r.Comment,
                Rating = r.Rating,
                Time = r.Time
            }).ToList();
            return reviewResponse;
        }

        public async Task<ReviewResponse> Update(ReviewRequest reviewRequest)
        {
            var review = await Task.Run(() => _context.Review.Where(r => r.Id == reviewRequest.Id));
            return (ReviewResponse)review.Select(r => new ReviewResponse
            {
                Id = r.Id,
                UserId = r.UserId,
                ProductId = r.ProductId,
                Content = r.Comment,
                Rating = r.Rating,
                Time = r.Time
            });
        }
    }
}