namespace Backend.Models;

public class Place
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; } = 5;
    public double Latitude { get; set; }
    public double Longitude { get; set; }


    //public string ImageUrl { get; set; }
}