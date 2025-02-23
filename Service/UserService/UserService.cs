namespace UserServices.Server
{
    public class UserService : IUserService
    {
        private readonly MarketProjectDbContext _context;

        public UserService(MarketProjectDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _context.User
                        .Select(u => new UserResponseDto
                        {
                            Id = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email
                        }).ToListAsync();
            return users;
        }

        public async Task<bool> LoginAsync(LoginRequest login)
        {
        var user = await _context.User.FirstOrDefaultAsync(u => u.Email == login.Email);

            if (user != null)
            {
                var userPassword = login.Password;
                var passwordBd = user.PasswordHash;
                bool result = VerifyPassword(userPassword, passwordBd);
                if(result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
            
        }

        public async Task<UserResponseDto> RegisterAsync(RegisterUserRequest registerUser)
        {
            if(await _context.User.AnyAsync(u => u.Email == registerUser.Email))
            {
                throw new Exception("Пользователь с таким email уже существует");
            }
            User user = new User
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                PasswordHash = GetPassword(registerUser.Password)
            };
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return new UserResponseDto
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email
            };
        }

        private static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
        private static string GetPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}