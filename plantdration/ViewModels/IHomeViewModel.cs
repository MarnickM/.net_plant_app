using plantdration.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plantdration.ViewModels
{
    public interface IHomeViewModel
    {
        User User { get; set; }
        ICommand AddPlantCommand {  get; set; }
        ICommand GoToUserPageCommand {  get; set; }
        ObservableCollection<PlantCardViewModel> PlantCards { get; }
        /*ObservableCollection<Plant> Plants { get; set; }*/
        /*ICommand ShowDetailsCommand { get; set; }*/

    }
}
