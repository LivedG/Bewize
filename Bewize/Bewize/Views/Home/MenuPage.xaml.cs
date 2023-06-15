using Xamarin.Forms;
using Bewize.ViewModels;
using Bewize.Models;
using System;
using System.Net;
using System.IO;
using Bewize.HelperResource;

namespace Bewize.Views.Home
{
    public partial class MenuPage : ContentPage
	{

        MenupageVM VM;

        public MenuPage ()
		{
			InitializeComponent ();
            VM = new MenupageVM();
            BindingContext = VM;
            VM.GetProfiledatafromlocalStorage();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
             if (VM.Profiledetails.profile_img != null && VM.Profiledetails.profile_img != "")
            {
                this.setupProfilepicture(VM.Profiledetails.profile_img);
            }          
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
    }
}

