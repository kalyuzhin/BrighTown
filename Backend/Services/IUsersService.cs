namespace Backend.Services;

public interface IUsersService
{
    Task<ServiceResponse<GetUserDto>> Register(AddUserDto user);
    Task<ServiceResponse<GetUserDto>> Authorize(AddUserDto request);

    Task<ServiceResponse<GetUserDto>> AddFriend(GetUserDto user);
}