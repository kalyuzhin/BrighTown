namespace Backend.Dtos.Place;

public class AddPlaceResponseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; } = 0;
    public double Latitude { get; set; } = 0.0;
    public double Longitude { get; set; } = 0.0;
}