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
        public string? PasswordHash
        {
            get => _password;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _password = BCrypt.Net.BCrypt.HashPassword(value);
                }
            }
        }
        public Role Role{ get; set;}

        public List<Review> Reviews{ get; set; } = new List<Review>();

        public List<Order> Orders{ get; set; } = new List<Order>();

        // //Превращает обычный парорль в хешированного
        // public void SetPasswod(string password)
        // {
        //     var hasher = new PasswordHasher<User>();
        //     PasswordHash = hasher.HashPassword(this, password);
        // }

        // //Проверяет, совпадает ли введённый пароль с хешированным значанием
        // public bool VerifyPassword(string password)
        // {
        //     var hasher = new PasswordHasher<User>();
        //     return hasher.VerifyHashedPassword(this, PasswordHash, password) == PasswordVerificationResult.Success;
        // }
    }
}