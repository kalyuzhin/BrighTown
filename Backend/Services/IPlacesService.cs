using Backend.Dtos.Pairs;

namespace Backend.Services;

public interface IPlacesService
{
    Task<ServiceResponse<List<GetPlaceRequestDto>>> GetAllPlaces();

    Task<ServiceResponse<GetPlaceRequestDto>> GetPlace(int id);

    Task<ServiceResponse<List<GetPlaceRequestDto>>> AddPlace(AddPlaceResponseDto newPlace);

    Task<ServiceResponse<GetPlaceRequestDto>> AddPlaceToFavourites(AddFavouritePlaceDto pair);

    Task<ServiceResponse<List<GetPlaceRequestDto>>> GetFavourites(int userId);
}