using plantdration.ViewModels;
using System.Diagnostics;

namespace plantdration.Views;

public partial class PlantDetailsView : ContentPage
{
	public PlantDetailsView(IPlantsDetailViewModel viewModel)
	{
        InitializeComponent();

        BindingContext = viewModel;
    }
}