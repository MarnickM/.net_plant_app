using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using plantdration.Messages;
using plantdration.Models;
using plantdration.Services;
using System;
using System.Collections.Generic;
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
    }
}
