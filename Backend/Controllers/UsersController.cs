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

        [HttpPost("register-user")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register(AddUserDto newUser)
        {
            return Ok(await _usersService.Register(newUser));
        }
    }
}