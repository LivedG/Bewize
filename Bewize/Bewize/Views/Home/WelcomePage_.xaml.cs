using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views.Home
{
    public partial class WelcomePage_ : ContentPage
    {
        WelcomepageVM VM;

        public WelcomePage_()
        {
            InitializeComponent();
            VM = new WelcomepageVM();
            BindingContext = VM;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.checkLocationAccess();
        }

        async void Currentlocationbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            //if (VM.zipcode != "")
            //{
            //    VM.MoveForwardwithZipcode(VM.zipcode);
            //}
            //else
            //{
            //    await App.Current.MainPage.DisplayAlert("", "valid Zipcode required", "OK");
            //}
           // await App.Current.MainPage.DisplayAlert("", "valid Zipcode required", "OK");
        }
    }
}

