namespace Backend.Services
{
    public interface IDatabaseService
    {
        void SaveUser(User user);
        bool CheckUserExists(string email);
    }
}
