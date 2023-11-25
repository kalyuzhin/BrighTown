namespace Backend.Models;

public class Place
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }
    
    //public string ImageUrl { get; set; }
}