namespace Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController( IUserService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDto>> Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                UserResponseDto user = await _service.RegisterAsync(request);
                return Ok(new ApiResponse<UserResponseDto>(user, "Пользователь успешно зарегистрирован"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> Login([FromBody] LoginRequest request)
        {
            try
            {
                bool user = await _service.LoginAsync(request);
                if (user)
                {
                    return Ok("Успешный вход");
                }
                else
                {
                    return BadRequest("Некорректные");
                }
            }
            catch (Exception ex)
            {
                return Unauthorized(new ApiResponse<string>(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(new ApiResponse<List<UserResponseDto>>(users, "Список пользовалетей"));
        }
    }

}