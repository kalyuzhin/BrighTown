namespace Backend.Models;

public class Place
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; } = 5;

   public Place(int id, string name, string description, double rating)
    {
        Id = id;
        Name = name;
        Description = description;
        Rating = rating;
    }
    //public string ImageUrl { get; set; }
}