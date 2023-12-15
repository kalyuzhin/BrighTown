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
        // if (db.ToList().Select(c => c.Email).Contains(newUser.Email))
        // {
        //     serviceResponse.Success = false;
        //     serviceResponse.Message = "This email address is already taken!";
        //     return serviceResponse;
        // }

        if (db.ToList().Select(c => c.Username).Contains(newUser.Username))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "This username is already taken!";
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
    
}