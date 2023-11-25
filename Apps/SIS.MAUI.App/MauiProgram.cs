﻿//using CommunityToolkit.Maui;
using CommunityToolkit.Maui;
using DotNurse.Injector;
using Mopups.Hosting;
using UraniumUI;
//using UraniumUI.Dialogs;
using Camera.MAUI;

namespace UraniumApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMediaElement()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .UseUraniumUIBlurs(false)
            .UseUraniumUIWebComponents()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFontAwesomeIconFonts();
                fonts.AddMaterialIconFonts();
                fonts.AddFluentIconFonts();
            })
            .UseMauiApp<App>()
            .UseMauiCameraView(); // Add the use of the plugging

        var thisAssembly = typeof(MauiProgram).Assembly;

        builder.Services.AddServicesFrom(
            type => typeof(Page).IsAssignableFrom(type),
            ServiceLifetime.Transient,
            options => options.Assembly = thisAssembly)
        .AddServicesByAttributes(assembly: thisAssembly);

        //builder.Services.AddCommunityToolkitDialogs();
        builder.Services.AddMopupsDialogs();

        return builder.Build();
    }
}
