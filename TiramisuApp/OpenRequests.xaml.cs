using TiramisuApp.Models;
using TiramisuApp.ViewModels;

namespace TiramisuApp;

public partial class OpenRequests : ContentPage
{
    private readonly OpenRequestsViewModel openRequestsViewModel;

    public OpenRequests(OpenRequestsViewModel openRequestsViewModel)
	{
		InitializeComponent();

        BindingContext = openRequestsViewModel;
        this.openRequestsViewModel = openRequestsViewModel;
    }

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		await openRequestsViewModel.GetOpenRequestsAsync();
	}
}