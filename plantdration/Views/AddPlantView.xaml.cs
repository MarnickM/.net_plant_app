using plantdration.ViewModels;

namespace plantdration.Views;

public partial class AddPlantView : ContentPage
{
    public AddPlantView(IAddPlantViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}