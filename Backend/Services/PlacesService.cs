using Backend.Dtos.Pairs;

namespace Backend.Services;

public class PlacesService : IPlacesService
{
    // private static List<Place> places = new List<Place>
    // {
    //     new Place { Id = 1, Name = "Di Pasta", Rating = 4.85, Description = "Restraunt" },
    //     new Place { Id = 2, Name = "Tasty and dot", Rating = 3.21, Description = "FastFood" }
    // };

    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;

    public PlacesService(IMapper mapper, DataContext dataContext)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    public async Task<ServiceResponse<List<GetPlaceRequestDto>>> GetAllPlaces()
    {
        var serviceResponse = new ServiceResponse<List<GetPlaceRequestDto>>();
        var db = await _dataContext.Places.ToListAsync();
        serviceResponse.Data = db.Select(c => _mapper.Map<GetPlaceRequestDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetPlaceRequestDto>> GetPlace(int id)
    {
        var serviceResponse = new ServiceResponse<GetPlaceRequestDto>();
        var db = await _dataContext.Places.ToListAsync();
        var place = db.FirstOrDefault(p => p.Id == id);
        serviceResponse.Data = _mapper.Map<GetPlaceRequestDto>(place);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetPlaceRequestDto>>> AddPlace(AddPlaceResponseDto newPlace)
    {
        var serviceResponse = new ServiceResponse<List<GetPlaceRequestDto>>();
        //var db = await _dataContext.Places.ToListAsync();
        var place = _mapper.Map<Place>(newPlace);
        var db = _dataContext.Places;
        if (db.ToList().Select(c => c.Name.ToLower()).Contains($@"{newPlace.Name.ToLower().Trim()}"))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "This place is already created";
            return serviceResponse;
        }

        //place.Id = db.Count == 0 ? 1 : db.Max(c => c.Id) + 1;
        //db.Add(place);
        place.Id = db.ToList().Select(c => c.Id).DefaultIfEmpty(0).Max() + 1;
        await db.AddAsync(place);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await db.Select(c => _mapper.Map<GetPlaceRequestDto>(c)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetPlaceRequestDto>> AddPlaceToFavourites(AddFavouritePlaceDto pair)
    {
        var serviceResponse = new ServiceResponse<GetPlaceRequestDto>();
        User? user = _dataContext.Users.FirstOrDefault(u => u.Id == pair.UserId);
        if (user == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "User doesn't exist";
            return serviceResponse;
        }

        Place? place = _dataContext.Places.FirstOrDefault(p => p.Id == pair.PlaceId);
        if (place == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Place doesn't exist";
            return serviceResponse;
        }

        var match = _dataContext.FavPlaces.FirstOrDefault(p => (p.UserId == user.Id) && (p.PlaceId == place.Id));
        if (match != null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "You already add this place to favourites";
            return serviceResponse;
        }

        var db = _dataContext.FavPlaces;
        await db.AddAsync(_mapper.Map<PlacesFavouritesPair>(pair));
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetPlaceRequestDto>(place);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetPlaceRequestDto>>> GetFavourites(int userId)
    {
        var serviceResponse = new ServiceResponse<List<GetPlaceRequestDto>>();
        var db_user = _dataContext.Users;
        if (db_user.FirstOrDefault(u => u.Id == userId) == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "User doesn't exist";
            return serviceResponse;
        }

        var places = await _dataContext.Places.ToListAsync();
        var ids = await _dataContext.FavPlaces.Where(p => p.UserId == userId).ToListAsync();
        serviceResponse.Data = new List<GetPlaceRequestDto>();
        foreach (var id in ids)
        {
            var place = places.FirstOrDefault(p => p.Id == id.PlaceId);
            serviceResponse.Data.Add(_mapper.Map<GetPlaceRequestDto>(place));
        }

        if (serviceResponse.Data.Count == 0)
        {
            serviceResponse.Message = "Вы еще не добавили ни одного места.";
        }

        return serviceResponse;
    }
}