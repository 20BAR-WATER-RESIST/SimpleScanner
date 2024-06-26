﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace SimpleScanner;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Configuration.AddJsonFile("secrets.json",
            optional: false,
            reloadOnChange: true
        );

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}