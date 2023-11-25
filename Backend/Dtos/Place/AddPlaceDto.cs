namespace Backend.Dtos.Place;

public class AddPlaceResponseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }
}