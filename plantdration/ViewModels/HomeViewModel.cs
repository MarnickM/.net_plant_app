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
        public void Receive(UserSelectedMessage message)
        {
            User = message.Value;
            LoadUserPlants();
        }

        public void Receive(RefreshPlantsMessage message)
        {
            LoadUserPlants();
        }

        private User user = new User();
        public User User
        {
            get => user;
            set
            {
                SetProperty(ref user, value);
            }
        }

        private ObservableCollection<Plant> plants = new ObservableCollection<Plant>();
        public ObservableCollection<Plant> Plants
        {
            get => plants;
            set
            {
                SetProperty(ref plants, value);
            }
        }

        private INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Messenger.Register<HomeViewModel, UserSelectedMessage>(this, (r, m) => r.Receive(m));
            Messenger.Register<HomeViewModel, RefreshPlantsMessage>(this, (r, m) => r.Receive(m));

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


        private void LoadUserPlants()
        {
            Plants.Clear();

            var userPlants = UserPlantDataService.GetByUserId(User.Id);

            foreach (var userPlant in userPlants)
            {
                var plant = PlantDataService.GetPlantById(userPlant.PlantId);
                if (plant != null)
                {
                    Plants.Add(plant);
                }
            }
        }

    }
}
