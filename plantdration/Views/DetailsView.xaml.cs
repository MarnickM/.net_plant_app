using plantdration.ViewModels;

namespace plantdration.Views;

public partial class DetailsView : ContentPage
{
    public DetailsView(IDetailsViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }


}