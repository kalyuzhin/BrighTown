using Backend.Models;

namespace Backend.Services;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;

    public UsersService(DataContext dataContext, IMapper mapper)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    public async Task<ServiceResponse<GetUserDto>> Register(AddUserDto newUser)
    {
        var serviceResponse = new ServiceResponse<GetUserDto>();
        var db = _dataContext.Users;

        if (db.ToList().Select(c => c.Username).Contains(newUser.Username))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "This username is already taken!";
            return serviceResponse;
        }

        if (db.ToList().Select(c => c.Email).Contains(newUser.Email))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "This email is already taken!";
            return serviceResponse;
        }

        if (string.IsNullOrWhiteSpace(newUser.Password))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Incorrect type of password!";
            return serviceResponse;
        }

        var user = _mapper.Map<User>(newUser);
        await db.AddAsync(user);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetUserDto>(user);
        return serviceResponse;
    }


    public async Task<ServiceResponse<GetUserDto>> Authorize(AddUserDto request)
    {
        var serviceResponse = new ServiceResponse<GetUserDto>();
        var db = await _dataContext.Users.ToListAsync();
        User? user = db.ToList().Find(u =>
            u.Password == request.Password && (u.Username == request.Username || u.Email == request.Email));

        if (user == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Wrong login or password";
            return serviceResponse;
        }

        serviceResponse.Data = _mapper.Map<GetUserDto>(user);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
    {
        var serviceResponse = new ServiceResponse<List<GetUserDto>>();
        var db = await _dataContext.Users.ToListAsync();
        serviceResponse.Data = db.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetUserDto>> AddFriend(UserFriendPair pair)
    {
        var serviceResponse = new ServiceResponse<GetUserDto>();
        var db_users =  _dataContext.Users;
        var db_friends =  _dataContext.Friends;
        if (!db_users.ToList().Exists(u => u.Id == pair.UserId))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "You don`t exist!";
            return serviceResponse;
        }
        User? found_friend = db_users.ToList().Find(f => f.Id == pair.FriendId);
        if (found_friend == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "This user doesn`t exist";
            return serviceResponse;
        }
        if (db_friends.ToList().Exists(uf => uf.UserId == pair.UserId && uf.FriendId == pair.FriendId))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "This user is already your friend.";
            return serviceResponse;
        }
        var uf_pair = new UserFriendPair();
        uf_pair.UserId = pair.UserId; uf_pair.FriendId = pair.FriendId;
        await db_friends.AddAsync(uf_pair);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetUserDto>(found_friend);
        return serviceResponse;
    }
}