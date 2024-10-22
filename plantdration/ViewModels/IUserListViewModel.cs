using plantdration.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace plantdration.ViewModels
{
    public interface IUserListViewModel
    {
        ICommand AddUserCommand {  get; set; }
        ICommand UpdateUserCommand { get; set; }
        User SelectedUser { get; set; }
        ObservableCollection<User> Users { get; set; }
    }
}
