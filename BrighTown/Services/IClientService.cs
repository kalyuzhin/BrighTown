using BrighTown.Models;

namespace BrighTown.Services;

public interface IClientService
{
    // Task<User> Login(string email, string password);

    Task<User> Register(RegisterModel model); //(string email, string username, string password);

    // void Register(User user);
}