using plantdration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plantdration.ViewModels
{
    public interface IAddPlantViewModel
    {
        User User { get; set; }
        ICommand PickPhotoCommand { get; set; }
        ICommand TakePhotoCommand { get; set; }
        ICommand AddPlantCommand { get; set; }
        ICommand GoBackCommand { get; set; }

        Plant ClassifiedPlant { get; set; }

        ImageSource Photo { get; set; }
    }
}
