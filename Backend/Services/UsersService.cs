using Microsoft.AspNetCore.Http.HttpResults;
using Xamarin.Forms;

namespace Backend.Services;

public class UsersService : IUsersService
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;

    public UsersService(DataContext dataContext, IMapper mapper)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    public async Task<ServiceResponse<GetUserDto>> Register(AddUserDto newUser)
    {
        var serviceResponse = new ServiceResponse<GetUserDto>();
        var db = _dataContext.Users;
        if (db.ToList().Select(c => c.Email).Contains(newUser.Email))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Эта почта уже занята!";
            return serviceResponse;
        }

        if (db.ToList().Select(c => c.Username).Contains(newUser.Username))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Этот никнейм уже занят!";
            return serviceResponse;
        }

        if (string.IsNullOrWhiteSpace(newUser.Password))
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Некорректный пароль!";
            return serviceResponse;
        }
        try
        {
        var user = _mapper.Map<User>(newUser);
        await db.AddAsync(user);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetUserDto>(user);

        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ой!", "К сожалению произошла ошибка...", "ОК");
        }
        return serviceResponse;
    }
    
}