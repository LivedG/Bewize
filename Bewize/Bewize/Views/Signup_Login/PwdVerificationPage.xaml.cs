using System;
using System.Collections.Generic;
using Bewize.Models;
using Bewize.RenderFiles;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views
{
    public partial class PwdVerificationPage : ContentPage
    {
        
       public PwdVerificationVM VM;


        public PwdVerificationPage()
        {
            InitializeComponent();

            VM = new PwdVerificationVM();
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

        async void Continuebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (countrycodetxt.Text != "" && numbertxt.Text != "" && countrycodetxt.Text != null && numbertxt.Text != null)
            {

                VM.Loginid = new Sendotp_reqPara();
                VM.Loginid.country_code = VM.selectedCountry.country_code;
                VM.Loginid.phone = numbertxt.Text;
                VM.SentOtp_continuebtnActionAsync();
            }
            else {
                await App.Current.MainPage.DisplayAlert("", "Please ennter all details.", "OK");

            }
        }
    }
}

