using ETS.Models;
using Javax.Security.Auth;
using static Android.Provider.Contacts;

namespace ETS;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

       
    }

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddContact());
	}

	private async void GetPeople (object sender, EventArgs e)
	{
        List<CompanyContact> contacts = await App.CompanyContactRepo.GetAllPeople();
        contactList.ItemsSource = contacts;
    }
}

