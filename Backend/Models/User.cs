namespace Backend.Models;

public class User
{
    public int Id { get; set; }

    // public string Email { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    // public string FirstName { get; set; } = string.Empty;
    //
    // public string SecondName { get; set; } = string.Empty;
    //
    // public List<Place> FavouritePlaces { get; set; } = new List<Place>();
    //
    // public List<User> Friends { get; set; } = new List<User>();
}