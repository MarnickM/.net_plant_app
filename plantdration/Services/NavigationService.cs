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
            // Dit is de slechte manier omdat we new DetailsPage(new DetailsViewModel(new NavigationService())) doen.
            //await _navigation.PushAsync(new DetailsPage(new DetailsViewModel(new NavigationService())));
            // Dit is de manier dat het moet met de serviceprovider. Je voegt de detailspagina toe aan de serviceprovider bij de mauiProgram.
            await _navigation.PushAsync(_serviceProvider.GetRequiredService<DetailsView>());
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
