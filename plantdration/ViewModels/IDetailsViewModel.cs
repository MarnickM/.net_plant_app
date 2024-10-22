using plantdration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace plantdration.ViewModels
{
    public interface IDetailsViewModel
    {
        ICommand SaveCommand { get; set; }
        ICommand DeleteCommand { get; set; }
        ICommand CancelCommand { get; set; }

        string SaveText { get; set; }
        bool CanDelete { get; }

        User User { get; set; }
    }
}
