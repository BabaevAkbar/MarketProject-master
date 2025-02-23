namespace Requests
{
    public class ReviewRequest
    {
        public Guid Id{ get; set; }
        public Guid UserId{ get; set; }
        public Guid ProductId{ get; set; }
        public string Content{ get; set; }
        public int Rating{ get; set; }
    }
}