namespace MarketProject.Models
{
    public class User
    {
        public Guid Id{ get; set;} = Guid.NewGuid();
        [Required]
        public string? FirstName{ get; set; }
        public string? LastName{ get; set; }
        [Required]
        [EmailAddress]
        public string? Email{ get; set; }
        [Required]
        private string? _password;
        public string? PasswordHash { get; set; }
        public Role Role{ get; set;}

        public List<Review> Reviews{ get; set; } = new List<Review>();

        public List<Order> Orders{ get; set; } = new List<Order>();

    }
}