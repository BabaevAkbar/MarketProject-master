namespace Responses
{
    public class ReviewResponse
    {
        public Guid Id{ get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string? Content {  get; set; }
        public int Rating { get; set; }
        public DateTime Time{ get; set; }
    }
}