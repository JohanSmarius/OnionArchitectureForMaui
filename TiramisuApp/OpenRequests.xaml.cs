using TiramisuApp.Models;
using TiramisuApp.ViewModels;

namespace TiramisuApp;

public partial class OpenRequests : ContentPage
{


	public OpenRequests()
	{
		InitializeComponent();

        BindingContext = new OpenRequestsViewModel();
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		await (BindingContext as OpenRequestsViewModel).GetOpenRequestsAsync();
	}
}