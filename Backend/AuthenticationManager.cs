namespace Backend
{
    public class AuthenticationManager
    {
        public bool AuthenticateUser(string username, string password)
        {
            // Пример проверки с фиктивными значениями
            return username == "admin" && password == "password";
        }
    }
}