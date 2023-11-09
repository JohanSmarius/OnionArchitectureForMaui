using TiramisuApp.ViewModels;

namespace TiramisuApp;

public partial class NewRequest : ContentPage
{
	public NewRequest()
	{
		InitializeComponent();

		BindingContext = new NewRequestViewModel();
	}
}