using Backend.Dtos.Pairs;
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

    public async Task<ServiceResponse<GetUserDto>> AddFriend(AddFriendDto pair)
    {
        var serviceResponse = new ServiceResponse<GetUserDto>();
        var db_users = _dataContext.Users;
        var db_friends = _dataContext.Friends;

        if (pair.FriendId == pair.UserId)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "You cannot add yourself";
            return serviceResponse;
        }

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
        uf_pair.UserId = pair.UserId;
        uf_pair.FriendId = pair.FriendId;
        await db_friends.AddAsync(uf_pair);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetUserDto>(found_friend);
        serviceResponse.Message = "Success";
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetUserDto>>> GetFriends(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetUserDto>>();
        serviceResponse.Data = new List<GetUserDto>();
        var db_users = _dataContext.Users.Select(u => _mapper.Map<GetUserDto>(u)).ToList();
        var db_friends = _dataContext.Friends.Where(p => p.UserId == id).ToList();
        foreach (var friend in db_friends)
        {
            var result = db_users.Where(u => u.Id == friend.FriendId).ToList().Count == 1
                ? db_users.Where(u => u.Id == friend.FriendId).ToList()[0]
                : null;
            if (result != null)
            {
                serviceResponse.Data.Add(result);
            }
        }

        if (serviceResponse.Data.Count == 0)
        {
            serviceResponse.Message = "У вас нет друзей :(";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> DeleteFriend(AddFriendDto pair)
    {
        var serviceResponse = new ServiceResponse<bool>();
        serviceResponse.Data = false;
        var db_users = _dataContext.Users.FirstOrDefault(u => u.Id == pair.FriendId);
        var db_frineds =
            _dataContext.Friends.FirstOrDefault(p => (p.UserId == pair.UserId) && (p.FriendId == pair.FriendId));
        if (db_users == null)
        {
            serviceResponse.Message = "User doesn't exist";
            return serviceResponse;
        }

        if (db_frineds == null)
        {
            serviceResponse.Message = "You are not a friends!!!";
            return serviceResponse;
        }

        if (_dataContext.Users.FirstOrDefault(u => u.Id == pair.UserId) == null)
        {
            serviceResponse.Message = "You don't exist";
            return serviceResponse;
        }

        // UserFriendPair ufp = _mapper.Map<UserFriendPair>(pair);
        UserFriendPair ufp =
            _dataContext.Friends.FirstOrDefault(p => p.FriendId == pair.FriendId && p.UserId == pair.UserId);
        _dataContext.Friends.Remove(ufp);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = true;

        return serviceResponse;
    }
}