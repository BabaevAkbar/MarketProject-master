namespace Requests
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password{ get; set; }
    }
}