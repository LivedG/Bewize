using System;
using System.Collections.Generic;
using Bewize.Models;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views.MyRating
{	
	public partial class MyRatingsListPage : ContentPage
	{
        MyratingsListVM VM;

		public MyRatingsListPage ()
		{
			InitializeComponent ();
            VM = new MyratingsListVM();
            BindingContext = VM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (VM.MyRatingsDetailsList != null && VM.MyRatingsDetailsList.Count > 0)
            {
                await App.Current.MainPage.DisplayAlert("", "Your ratings list is empty!.", "OK");

            }
           
        }


        public void Backbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Home.MyHomepage());
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            VM.MoveForwardtoViewdetails();
        }

        // View Tapped
        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            VM.MoveForwardtoViewdetails();
        }

    }
}

