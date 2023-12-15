namespace BrighTown.Models;


public class User
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;
    
    public string SecondName { get; set; } = string.Empty;
    
    public List<Place> FavouritePlaces { get; set; } = new List<Place>();
    
    public List<User> Friends { get; set; } = new List<User>();

    public User(int Id, string Email, string Username, string Password, string FirstName, string SecondName)
    {
        this.FirstName = FirstName;
        this.Username = Username;
        this.Password = Password;
        this.Email = Email;
        this.Id = Id;
        this.SecondName = SecondName;
    }
}