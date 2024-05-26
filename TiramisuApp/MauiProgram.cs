using Microsoft.Extensions.Logging;
using TiramisuApp.Infrastructure;
using TiramisuApp.Services;
using TiramisuApp.ViewModels;

namespace TiramisuApp
{
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<NewRequest>();
            builder.Services.AddTransient<OpenRequests>();
            builder.Services.AddTransient<OpenRequestsViewModel>();
            builder.Services.AddTransient<NewRequestViewModel>();
            builder.Services.AddTransient<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IRequestService, RequestService>();
            builder.Services.AddSingleton<IClothingRepository, ClothingRepository>();
            builder.Services.AddSingleton<IClothingCache, ClothingCache>();
            builder.Services.AddSingleton<IDeviceStatus, DeviceStatus>();
            return builder.Build();
        }
    }
}
