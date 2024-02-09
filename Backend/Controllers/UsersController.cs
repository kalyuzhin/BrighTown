namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // [HttpPost("/user/register/{email}/{username}/{password}")]
        [HttpPost("/register")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register(string username, string password, string email)
        {
            var newUser = new AddUserDto();
            newUser.Username = username;
            newUser.Password = password;
            newUser.Email = email;
            return Ok(await _usersService.Register(newUser));
        }

        [HttpPost("/login")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Authorize(AddUserDto newUser)
        {
            return Ok(await _usersService.Authorize(newUser));
        }
    }
}