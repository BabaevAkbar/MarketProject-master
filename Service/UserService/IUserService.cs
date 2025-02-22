namespace Service.IUserService
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllUsersAsync();
        Task<bool> LoginAsync(LoginRequest login);
        Task<UserResponseDto> RegisterAsync(RegisterUserRequest registerUser);
    }
}