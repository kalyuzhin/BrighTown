using Backend.Dtos.Pairs;

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

        // [HttpPost("/register/{email}/{username}/{password}")]
        [HttpPost("/register")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register(AddUserDto newUser)
        {
            // var newUser = new AddUserDto();
            // newUser.Username = username;
            // newUser.Password = password;
            // newUser.Email = email;
            return Ok(await _usersService.Register(newUser));
        }

        [HttpPost("/login")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Authorize(AddUserDto newUser)
        {
            return Ok(await _usersService.Authorize(newUser));
        }

        [HttpPost("/add_friend")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> AddFriend(AddFriendDto pair)
        {
            return Ok(await _usersService.AddFriend(pair));
        }

        [HttpGet("/getallusers")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetAllUsers()
        {
            return Ok(await _usersService.GetAllUsers());
        }

        [HttpPost("/getfriends")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetFriends(int id)
        {
            return Ok(await _usersService.GetFriends(id));
        }

        [HttpDelete("/deletefriend")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteFriend(AddFriendDto pair)
        {
            return Ok(await _usersService.DeleteFriend(pair));
        }
    }
}