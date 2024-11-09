using plantdration.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plantdration.Services
{
    public class NavigationService : INavigationService
    {
        private INavigation _navigation;

        private IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _navigation = Application.Current.MainPage.Navigation;
        }

        public async Task NavigateToDetailsPageAsync()
        {
            await _navigation.PushAsync(_serviceProvider.GetRequiredService<DetailsView>());
        }

        public async Task NavigateToHomePageAsync()
        {
            await _navigation.PushAsync(_serviceProvider.GetRequiredService<HomeView>());
        }

        public async Task NavigateToAddPlantPageAsync()
        {
            await _navigation.PushAsync(_serviceProvider.GetRequiredService<AddPlantView>());
        }

        public async Task NavigateToPlantDetailsPageAsync()
        {
            await _navigation.PushAsync(_serviceProvider.GetRequiredService<PlantDetailsView>());
        }

        public async Task NavigateToUserPageAsync()
        {
            await _navigation.PushAsync(_serviceProvider.GetRequiredService<UserListView>());
        }

        public async Task NavigateBackAsync()
        {
            if (_navigation.NavigationStack.Count > 1)
            {
                await _navigation.PopAsync();
            }
            else
            {
                throw new InvalidOperationException("No pages to navigate back to!");
            }
        }

    }
}
