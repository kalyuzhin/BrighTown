namespace Backend.Dtos.User;

public class AddUserDto
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string SecondName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<Models.Place> FavouritePlaces { get; set; } = new List<Models.Place>();
    public List<Models.User> Friends { get; set; } = new List<Models.User>();
}