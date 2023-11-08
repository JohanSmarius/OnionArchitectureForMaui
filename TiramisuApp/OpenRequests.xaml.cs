using TiramisuApp.Models;

namespace TiramisuApp;

public partial class OpenRequests : ContentPage
{
	public OpenRequests()
	{
		InitializeComponent();

        RequestedItems.ItemsSource = GenerateRequests();
	}

    private List<ClothingRequest> GenerateRequests()
    {
        return
        [
            new ClothingRequest { Age = 8, Gender = Gender.Girl, DesiredSize = "M", RequestedClothes = "Shirt, Pants" },
            new ClothingRequest { Age = 12, Gender = Gender.Girl, DesiredSize = "L", RequestedClothes = "Coat" }
        ];
    }
}