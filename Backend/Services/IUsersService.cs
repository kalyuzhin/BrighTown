namespace Backend.Services;

public interface IUsersService
{
    Task<ServiceResponse<GetUserDto>> Register(AddUserDto user);

    // Task<ServiceResponse<GetUserDto>> AddFriend(GetUserDto user);
}