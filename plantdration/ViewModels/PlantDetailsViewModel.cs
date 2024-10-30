using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using plantdration.Messages;
using plantdration.Models;
using plantdration.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plantdration.ViewModels
{
    public class PlantDetailsViewModel : ObservableRecipient, IPlantsDetailViewModel, IRecipient<PlantSelectedMessage>
    { 

        private UserPlant selectedUserPlant;
        public UserPlant SelectedUserPlant
        {
            get => selectedUserPlant;
            set => SetProperty(ref selectedUserPlant, value);
        }

        private Plant selectedPlant;
        public Plant SelectedPlant
        {
            get => selectedPlant;
            set => SetProperty(ref selectedPlant, value);
        }

        public async void Receive(PlantSelectedMessage message)
        {
            SelectedUserPlant = message.Value;
            Debug.WriteLine(SelectedUserPlant.PlantId);
            Debug.WriteLine(SelectedUserPlant.UserId);
            SelectedPlant = await PlantDataService.GetPlantById(SelectedUserPlant.PlantId);
            Debug.WriteLine(selectedPlant.Id);
            Debug.WriteLine(selectedPlant.Name);
        }

        private readonly INavigationService _navigationService;
        public PlantDetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Register<PlantDetailsViewModel, PlantSelectedMessage>(this, (r, m) => r.Receive(m));
            BindCommands();
        }


        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand UpdateWateringDateCommand { get; set; }

        private void BindCommands()
        {
            /*SaveCommand = new AsyncRelayCommand(SavePlantDetails);*/
            CancelCommand = new AsyncRelayCommand(Back);
            UpdateWateringDateCommand = new RelayCommand(UpdateWateringDate);
        }

        private async void UpdateWateringDate()
        {
            SelectedUserPlant.LastWatered = DateTime.Now;
            await UserPlantDataService.UpdateUserPlant(SelectedUserPlant);
        }

        /*        private async Task SavePlantDetails()
                {
                    await _navigationService.NavigateToHomePageAsync();
                    UserPlantDataService.UpdateUserPlant(SelectedUserPlant);
                }*/

        private async Task Back()
        {
            await _navigationService.NavigateBackAsync();
        }
    }
}
