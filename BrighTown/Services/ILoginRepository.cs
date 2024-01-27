using BrighTown.Models;

namespace BrighTown.Services;

public interface ILoginRepository
{
    // Task<User> Login(string email, string password);

    Task<User> Register(string username, string password); //(string email, string username, string password);

    // void Register(User user);
}