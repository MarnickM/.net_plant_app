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
    public class DetailsViewModel : ObservableRecipient, IDetailsViewModel, IRecipient<UserSelectedMessage>
    {
        public void Receive(UserSelectedMessage message)
        {
            User = message.Value;
            SaveText = "Update";
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

        private string saveText = "Add";

        public string SaveText
        {
            get => saveText;
            set
            {
                SetProperty(ref saveText, value);
                OnPropertyChanged(nameof(CanDelete));
            }
        }

        public bool CanDelete
        {
            get => SaveText == "Update";
        }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private INavigationService _navigationService;

        public DetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Messenger.Register<DetailsViewModel, UserSelectedMessage>(this, (r, m) => r.Receive(m));

            BindCommands();
        }

        private void BindCommands()
        {
            SaveCommand = new AsyncRelayCommand(SaveAndGoBack);
            DeleteCommand = new AsyncRelayCommand(DeleteAndGoBack);
            CancelCommand = new AsyncRelayCommand(GoBack);
        }

        private async Task SaveAndGoBack()
        {
            if (SaveText == "Add")
            {
                await UserDataService.InsertUserAsync(User);
            }
            else
            {
                await UserDataService.UpdateUserAsync(User);
            }
            WeakReferenceMessenger.Default.Send(new RefreshUsersMessage());
            await _navigationService.NavigateBackAsync();
        }

        private async Task DeleteAndGoBack()
        {
            await UserDataService.DeleteUserAsync(User.Id);
            WeakReferenceMessenger.Default.Send(new RefreshUsersMessage());
            await _navigationService.NavigateBackAsync();
        }

        private async Task GoBack()
        {
            await _navigationService.NavigateBackAsync();
        }
    }
}
