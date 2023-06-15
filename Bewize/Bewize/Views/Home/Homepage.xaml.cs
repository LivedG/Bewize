using System;
using System.Collections.Generic;

using Xamarin.Essentials;
//using Xamarin.Forms.Maps;
using Xamarin.Forms;
using Xamarin.Forms;
using Bewize.ViewModels;
using Bewize.HelperResource;

namespace Bewize.Views.Home
{
    public partial class Homepage : ContentPage
    {
        CurrentLocationHomepgVM VM;

        public Homepage()
        {
            InitializeComponent();
            VM = new CurrentLocationHomepgVM();
            BindingContext = VM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Object, String>(this, "Profilepic", async (obj, item) =>
            {
                var i = item as String;
                this.setupProfilepicture(i);
            });
            VM.getlocationdetailswithScore();
        }
        async void setupProfilepicture(string picurl)
        {
            try
            {
                var imagebytes = ImageService.DownlodaImage(picurl);
                ImageService.SavetoDisk("Profilepic", imagebytes);
                profileimage.Source = ImageService.GetFromDisk("Profilepic");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");
            }
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();

          
        }

       

    }
}

