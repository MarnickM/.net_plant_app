using plantdration.ViewModels;

namespace plantdration.Views;

public partial class UserListView : ContentPage
{
	public UserListView(IUserListViewModel viewModel)
	{
        InitializeComponent();

		BindingContext = viewModel;
	}
}