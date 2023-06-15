using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Xamarin.Forms;
using Bewize.Models;

namespace Bewize.Views.Profile
{	
	public partial class Acc_NumberverificationPage : ContentPage
	{
        Acc_NumberverificationpgVM VM;

        public Acc_NumberverificationPage ()
		{
			InitializeComponent ();
            VM = new Acc_NumberverificationpgVM();
            BindingContext = VM;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Object, Country>(this, "selectedcountry", async (obj, item) =>
            {
                var i = item as Country;
                VM.selectedCountry = i;

            });
        }

        public void Countrycodetxt_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
           VM.CountrycodeselectionAsync();
        }

        public async void Continuebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (Countrycodetxt.Text != null && pnumbertxt.Text != null) {
                VM.MoveForwardtoMAtchOTP(); }
            else {
                await App.Current.MainPage.DisplayAlert("", "All fields are required", "OK");
            }
        }
    }
}

