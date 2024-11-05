using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using plantdration.Messages;
using plantdration.Models;
using plantdration.Services;
using System.Windows.Input;

namespace plantdration.ViewModels
{
    public class PlantCardViewModel : ObservableObject
    {
        public Plant Plant { get; }
        public UserPlant UserPlant { get; }
        public ICommand ShowDetailsCommand { get; }
        public ICommand DeletePlantFromUserCommand { get; }

        private INavigationService _navigationService;
        public PlantCardViewModel(Plant plant, UserPlant userPlant, INavigationService navigationService)
        {
            _navigationService = navigationService;
            Plant = plant;
            UserPlant = userPlant;
            ShowDetailsCommand = new AsyncRelayCommand(ShowDetails);
            DeletePlantFromUserCommand = new AsyncRelayCommand(DeletePlant);
        }

        private async Task ShowDetails()
        {
            await _navigationService.NavigateToPlantDetailsPageAsync();
            WeakReferenceMessenger.Default.Send(new PlantSelectedMessage(UserPlant));
        }

        private async Task DeletePlant()
        {
            await UserPlantDataService.DeleteUserPlant(UserPlant);
            WeakReferenceMessenger.Default.Send(new RefreshPlantListMessage());
        }

    }
}
