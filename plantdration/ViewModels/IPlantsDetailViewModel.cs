using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using plantdration.Models;

namespace plantdration.ViewModels
{
    public interface IPlantsDetailViewModel
    {
        UserPlant SelectedUserPlant { get; set; }
        Plant SelectedPlant { get; set; }
        ICommand CancelCommand { get; set; }
        ICommand UpdateWateringDateCommand { get; set; }
    }
}
