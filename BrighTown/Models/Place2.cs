namespace BrighTown.Models;

public class Place2
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; } = 5;
    public double Latitude { get; set; } = 0;
    public double Longitude { get; set; } = 0;
    public string ImageUrl { get; set; } = string.Empty;
}