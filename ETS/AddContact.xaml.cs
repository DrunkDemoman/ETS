using ETS.Models;
using System.Collections.Generic;
namespace ETS;

public partial class AddContact : ContentPage
{
	public AddContact()
	{
		InitializeComponent();
	}

	public async void OnSubmitButtonClicked (object sender, EventArgs args)
	{

        statusMessage.Text = "";

        await App.CompanyContactRepo.AddNewContact(name.Text, company.Text, email.Text, companynumber.Text, phonenumber.Text);

		statusMessage.Text = App.CompanyContactRepo.StatusMessage;

    }
}