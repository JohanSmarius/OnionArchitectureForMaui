using Domain;
using TiramisuApp.ViewModels;

namespace TiramisuApp;

public partial class OpenRequests : ContentPage
{
    public OpenRequests(OpenRequestsViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
	}
}