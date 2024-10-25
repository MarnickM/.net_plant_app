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
        }

        public ICommand PickPhotoCommand { get; set; }
        public ICommand TakePhotoCommand { get; set; }

        public HomeViewModel()
        {
            BindCommands();
        }

        private void BindCommands()
        {
            PickPhotoCommand = new AsyncRelayCommand(PickAndClassifyPhoto);
            TakePhotoCommand = new AsyncRelayCommand(TakeAndClassifyPhoto);
        }

        private async Task PickAndClassifyPhoto()
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();
            /*await ClassifyPhotoAsync(photo);*/
        }

        private async Task TakeAndClassifyPhoto()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            /*await ClassifyPhotoAsync(photo);*/
        }
    }
}
