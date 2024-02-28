namespace BrighTown.Models;

public class Place
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; } = 5;
    public string ImageUrl { get; set; }

    public List<string> ImagesList { get; set; }
}