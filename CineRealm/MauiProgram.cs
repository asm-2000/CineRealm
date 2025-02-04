﻿using CineRealm.Pages;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace CineRealm
{
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MoviesPage>();
            builder.Services.AddSingleton<TVSeriesPage>();
            builder.Services.AddTransient<MovieDetailPage>();
            return builder.Build();
        }
    }
}
