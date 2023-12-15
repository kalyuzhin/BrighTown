namespace Backend;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Place, GetPlaceRequestDto>();
        CreateMap<AddPlaceResponseDto, Place>();
        CreateMap<User, GetUserDto>();
        CreateMap<AddUserDto, User>();
    }
}