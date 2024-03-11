using BrighTown.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BrighTown.ViewModels;

[QueryProperty(nameof(Friend), "CurrentFriendInfoPage")]
public partial class FriendDetailsViewModel : BaseViewModel
{
    [ObservableProperty] User _friend;
}