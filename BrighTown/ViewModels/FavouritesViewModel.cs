using System.Net.Http.Json;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;
using BrighTown.Models;

namespace BrighTown.ViewModels;

public partial class FavouritesViewModel : BaseViewModel
{
    [RelayCommand]
    async Task<List<Friend>> GetFriends()
    {
        List<Friend> friends = new List<Friend>();
        if (IsBusy)
        {
            return friends;
        }

        try
        {
            IsBusy = true;
            using var stream = await FileSystem.OpenAppPackageFileAsync("Places/places.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            friends = JsonSerializer.Deserialize<List<Friend>>(contents);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Warning", "Warning", "OK");
        }
        finally
        {
            IsBusy = false;
        }
        return friends;
    }
}