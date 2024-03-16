using Backend.Dtos.Pairs;

namespace Backend.Services;

public interface IUsersService
{
    Task<ServiceResponse<GetUserDto>> Register(AddUserDto user);
    Task<ServiceResponse<GetUserDto>> Authorize(AddUserDto request);

    Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();

    Task<ServiceResponse<GetUserDto>> AddFriend(AddFriendDto pair);

    Task<ServiceResponse<List<GetUserDto>>> GetFriends(int id);

    Task<ServiceResponse<bool>> DeleteFriend(AddFriendDto pair);
}