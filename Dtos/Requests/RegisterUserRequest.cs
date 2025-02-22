namespace Requests
{
    public class RegisterUserRequest
    {
        //public Guid Id{ get; set; }
        [Required]
        public string? FirstName{ get; set; }
        public string? LastName{ get; set; }
        [Required]
        [EmailAddress]
        public string? Email{ get; set; }
        [Required]
        [MinLength(6)]
        public string? Password{ get; set; }
    }
}