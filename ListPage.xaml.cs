using Rental_App.Models;

namespace Rental_App;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (RentalList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveRentalListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (RentalList)BindingContext;
        await App.Database.DeleteRentalListAsync(slist);
        await Navigation.PopAsync();
    }
}