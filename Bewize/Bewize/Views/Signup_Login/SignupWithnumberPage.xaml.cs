using System;
using System.Collections.Generic;
using Bewize.Models;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views.Signup_Login
{	
	public partial class SignupWithnumberPage : ContentPage
	{
		SignupwithnumberVM VM;

		public SignupWithnumberPage ()
		{
			InitializeComponent ();
			VM = new SignupwithnumberVM();
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
        public void CustomEntry_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            VM.CountrycodeselectionAsync();
        }

        async void CreateAccountbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (countytxt.Text != null && pnumbertxt.Text != null)
            {
                if (pnumbertxt.Text.Length != VM.selectedCountry.ph_length)
                {
                    await App.Current.MainPage.DisplayAlert("", "The number you entered is not valid.", "OK");
                    pnumbertxt.Text = string.Empty;
                }
                else
                {

                    Registeruserbynumber userdetails = new Registeruserbynumber();
                    userdetails.country_code = countytxt.Text;
                    userdetails.phone = pnumbertxt.Text;

                    VM.Register_newuser(userdetails);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", "All fields are mandatory.", "OK");
                pnumbertxt.Text = string.Empty;
                countytxt.Text = string.Empty;
            
            }
           
        }
    }
}

