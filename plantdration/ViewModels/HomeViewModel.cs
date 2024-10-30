using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using plantdration.Messages;
using plantdration.Models;
using plantdration.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plantdration.ViewModels
{
    public class HomeViewModel : ObservableRecipient, IHomeViewModel, IRecipient<UserSelectedMessage>
    {
        public async void Receive(UserSelectedMessage message)
        {
            User = message.Value;
            await LoadUserPlants();
        }

        private User user = new User();
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        /*        private ObservableCollection<Plant> plants = new ObservableCollection<Plant>();
        public ObservableCollection<Plant> Plants
        {
            get => plants;
            set
            {
                SetProperty(ref plants, value);
            }
        }
*/
        public ObservableCollection<PlantCardViewModel> PlantCards { get; } = new ObservableCollection<PlantCardViewModel>();

        private INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Messenger.Register<HomeViewModel, UserSelectedMessage>(this, (r, m) => r.Receive(m));

            BindCommands();
        }

        
        public ICommand AddPlantCommand { get; set; }

        private void BindCommands()
        {
            AddPlantCommand = new AsyncRelayCommand(GoToAddPlant);
        }

        private async Task GoToAddPlant()
        {
            await _navigationService.NavigateToAddPlantPageAsync();
            WeakReferenceMessenger.Default.Send(new UserSelectedMessage(user));
        }

        private async Task LoadUserPlants()
        {
           PlantCards.Clear();
           var userPlants = await UserPlantDataService.GetByUserId(User.Id);
           foreach (var userPlant in userPlants)
           {
              var plant = await PlantDataService.GetPlantById(userPlant.PlantId);
              if (plant != null)
              {
                    PlantCards.Add(new PlantCardViewModel(plant, userPlant, _navigationService));
              }
           }
        }
    }
}
