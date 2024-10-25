using plantdration.ViewModels;

namespace plantdration.Views;

public partial class HomeView : ContentPage
{
    public HomeView(IHomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
