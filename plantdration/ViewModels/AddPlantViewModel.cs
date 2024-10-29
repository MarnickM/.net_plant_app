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
    public class AddPlantViewModel : ObservableRecipient, IAddPlantViewModel, IRecipient<UserSelectedMessage>
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

        private ImageSource photo;

        public ImageSource Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }

        private Plant classifiedPlant;

        public Plant ClassifiedPlant
        {
            get => classifiedPlant;
            set => SetProperty(ref classifiedPlant, value);
        }

        private INavigationService _navigationService;
        public AddPlantViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Messenger.Register<AddPlantViewModel, UserSelectedMessage>(this, (r, m) => r.Receive(m));

            BindCommands();
        }

        public ICommand PickPhotoCommand { get; set; }
        public ICommand TakePhotoCommand { get; set; }
        public ICommand AddPlantCommand { get; set; }

        private void BindCommands()
        {
            PickPhotoCommand = new AsyncRelayCommand(PickAndClassifyPhoto);
            TakePhotoCommand = new AsyncRelayCommand(TakeAndClassifyPhoto);
            AddPlantCommand = new AsyncRelayCommand(AddPlantToCollection);
        }

        private async Task PickAndClassifyPhoto()
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();
            await ClassifyPhotoAsync(photo);
        }

        private async Task TakeAndClassifyPhoto()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            await ClassifyPhotoAsync(photo);
        }

        private async Task ClassifyPhotoAsync(FileResult photo)
        {
            if (photo is { })
            {
                ClassifiedPlant = new Plant();

                // Resize to allowed size - 4MB
                var resizedPhoto = await PhotoImageService.ResizePhotoStreamAsync(photo);
                Photo = ImageSource.FromStream(() => new MemoryStream(resizedPhoto));

                // Custom Vision API call
                var result = await CustomVisionService.ClassifyImageAsync(new MemoryStream(resizedPhoto));
                // Change the percentage notation from 0.9 to display 90.0%
                var percent = result?.Probability.ToString("P1");

                if (result.TagName.Equals("Negative"))
                {
                    ClassifiedPlant.Name = "This is not a known plant.";
                }
                else
                {
                    ClassifiedPlant = await PlantDataService.GetPlantByTag(result.TagName)!;
                    ClassifiedPlant.Name += " " + percent;
                }
            }
        }

        private async Task AddPlantToCollection()
        {
            if (ClassifiedPlant != null)
            {
                var userPlant = new UserPlant
                {
                    UserId = User.Id,
                    PlantId = ClassifiedPlant.Id,
                    DateAssigned = DateTime.Now
                };

                /*UserPlantDataService.AddUserPlant(userPlant);*/

                await _navigationService.NavigateToHomePageAsync();
                WeakReferenceMessenger.Default.Send(new UserSelectedMessage(User));
            }
        }

    }
}
