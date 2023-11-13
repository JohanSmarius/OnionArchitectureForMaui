using TiramisuApp.ViewModels;

namespace TiramisuApp;

public partial class NewRequest : ContentPage
{
	public NewRequest(NewRequestViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}