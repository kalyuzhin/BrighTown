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
}