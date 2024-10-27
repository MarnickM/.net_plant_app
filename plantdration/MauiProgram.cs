using Microsoft.Extensions.Logging;
using plantdration.Services;
using plantdration.ViewModels;
using plantdration.Views;

namespace plantdration
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

            builder.Services.AddTransient<INavigationService, NavigationService>();

            builder.Services.AddTransient<UserListView>();
            builder.Services.AddTransient<IUserListViewModel, UserListViewModel>();

            builder.Services.AddTransient<DetailsView>();
            builder.Services.AddTransient<IDetailsViewModel, DetailsViewModel>();

            builder.Services.AddTransient<HomeView>();
            builder.Services.AddTransient<IHomeViewModel, HomeViewModel>();

            builder.Services.AddTransient<AddPlantView>();
            builder.Services.AddTransient<IAddPlantViewModel, AddPlantViewModel>();

            return builder.Build();
        }
    }
}
