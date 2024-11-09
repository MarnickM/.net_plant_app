using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using plantdration.Messages;
using plantdration.Models;
using plantdration.Services;
using plantdration.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace plantdration.ViewModels
{
    public class UserListViewModel : ObservableRecipient, IUserListViewModel, IRecipient<RefreshUsersMessage>
    {
        public void Receive(RefreshUsersMessage message)
        {
            LoadUsers();
        }

        private ObservableCollection<User> users;

        public ObservableCollection<User> Users
        {
            get => users;
            set => SetProperty(ref users, value);
        }

        private User selectedUser;

        public User SelectedUser
        {
            get => selectedUser;
            set => SetProperty(ref selectedUser, value);
        }

        public ICommand AddUserCommand { get; set; }
        public ICommand SelectUserCommand { get; set; }

        private INavigationService _navigationService;

        public UserListViewModel(INavigationService navigationService)
        {
            LoadUsers();
            BindCommands();

            Messenger.Register<UserListViewModel, RefreshUsersMessage>(this, (r, m) => r.Receive(m));

            _navigationService = navigationService;
        }

        private async void LoadUsers()
        {
            Users = new ObservableCollection<User>(await UserDataService.GetUsersAsync());
        }

        private void BindCommands()
        {
            AddUserCommand = new AsyncRelayCommand(GoToDetailsAdd);
            SelectUserCommand = new AsyncRelayCommand(GoToHome);

        }

        private async Task GoToDetailsAdd()
        {
            await _navigationService.NavigateToDetailsPageAsync();
        }

        private async Task GoToHome()
        {
            await _navigationService.NavigateToHomePageAsync();
            WeakReferenceMessenger.Default.Send(new UserSelectedMessage(selectedUser));
        }
    }
}
