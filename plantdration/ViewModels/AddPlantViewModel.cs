using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using plantdration.Messages;
using plantdration.Models;
using plantdration.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private string percentage;
        public string Percentage
        {
            get => percentage;
            set => SetProperty(ref percentage, value);
        }
        private string warningMessage;
        public string WarningMessage
        {
            get => warningMessage;
            set => SetProperty(ref warningMessage, value);
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
        public ICommand GoBackCommand { get; set; }
        private void BindCommands()
        {
            PickPhotoCommand = new AsyncRelayCommand(PickAndClassifyPhoto);
            TakePhotoCommand = new AsyncRelayCommand(TakeAndClassifyPhoto);
            AddPlantCommand = new AsyncRelayCommand(AddPlantToCollection);
            GoBackCommand = new AsyncRelayCommand(GoBack);
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
        private string photoPath;
        public string PhotoPath
        {
            get => photoPath;
            set => SetProperty(ref photoPath, value);
        }
        private async Task ClassifyPhotoAsync(FileResult photo)
        {
            if (photo is { })
            {
                ClassifiedPlant = new Plant();
                // Resize to allowed size - 4MB
                var resizedPhoto = await PhotoImageService.ResizePhotoStreamAsync(photo);
                // Convert resized photo to byte array
                byte[] photoBytes;
                using (var ms = new MemoryStream())
                {
                    await ms.WriteAsync(resizedPhoto, 0, resizedPhoto.Length);
                    photoBytes = ms.ToArray();
                }
                photoPath = Path.Combine(FileSystem.AppDataDirectory, $"{Guid.NewGuid()}.jpg");
                File.WriteAllBytes(photoPath, photoBytes);
                Debug.WriteLine("AppData Directory: " + FileSystem.AppDataDirectory);
                Photo = ImageSource.FromFile(photoPath);
                // Custom Vision API call
                var result = await CustomVisionService.ClassifyImageAsync(new MemoryStream(resizedPhoto));
                // Change the percentage notation from 0.9 to display 90.0%
                var percent = result?.Probability.ToString("P1");
                if (result.TagName.Equals("Negative"))
                {
                    ClassifiedPlant.Name = "This is not a known plant.";
                    WarningMessage = "Could not classify this plant.";
                }
                else
                {
                    ClassifiedPlant = await PlantDataService.GetPlantByTag(result.TagName)!;
                    Percentage = percent;

                    // Check if percentage is below 80%
                    if (result.Probability < 0.80)
                    {
                        WarningMessage = "⚠️ Low Confidence, the accuracy for this image is low";
                    }
                    else
                    {
                        WarningMessage = string.Empty;
                    }
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
                    DateAssigned = DateTime.Now,
                    PhotoPath = photoPath
                };
                await UserPlantDataService.CreateUserPlant(userPlant);
                Debug.WriteLine("UserPlant created");
                await _navigationService.NavigateToHomePageAsync();
                WeakReferenceMessenger.Default.Send(new UserSelectedMessage(User));
            }
        }
        private async Task GoBack()
        {
            await _navigationService.NavigateBackAsync();
        }
    }
}
