﻿using BrighTown.Pages;
using BrighTown.ViewModels;
using CommunityToolkit.Maui;
using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Maui;
using Microsoft.Extensions.Logging;

namespace BrighTown;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Rounds.ttf", "RoundsBlack");
            });
        builder.Services.AddSingleton(Connectivity.Current);
        builder.Services.AddSingleton<NewAuthenticationViewModel>();
        // builder.Services.AddSingleton<AuthenticationPage>();
        builder.Services.AddSingleton<NewAuthenticationPage>();
        builder.Services.AddSingleton<MapPage>();
        builder.Services.AddSingleton<FavouritesPage>();
        builder.Services.AddSingleton<FriendsPage>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.UseArcGISRuntime(config =>
            config.UseApiKey(
                "AAPK0cf905d7ea244bfbae7d5d62f5b4d476-3kbqUfa0vXuT3WOM6tPIWvmL714wXqi8CmDzt9AivhZGrfTWuy3xRUGi_T1f886")); // ac

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}