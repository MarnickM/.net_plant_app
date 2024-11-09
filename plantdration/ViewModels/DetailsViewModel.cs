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
    public class DetailsViewModel : ObservableRecipient, IDetailsViewModel
    {
        private User user = new User();

        public User User
        {
            get => user;
            set
            {
                SetProperty(ref user, value);
            }
        }

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private INavigationService _navigationService;

        public DetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            BindCommands();
        }

        private void BindCommands()
        {
            SaveCommand = new AsyncRelayCommand(SaveAndGoBack);
            CancelCommand = new AsyncRelayCommand(GoBack);
        }

        private async Task SaveAndGoBack()
        {
            
            await UserDataService.InsertUserAsync(User);
            WeakReferenceMessenger.Default.Send(new RefreshUsersMessage());
            await _navigationService.NavigateBackAsync();
        }

        private async Task GoBack()
        {
            await _navigationService.NavigateBackAsync();
        }
    }
}
