using System;
using Bewize.HelperResource;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views.Profile
{
    public partial class AccountSettingPage : ContentPage
	{
		AccountsettingVM vm;
	

		public AccountSettingPage ()
		{
			InitializeComponent ();
			vm = new AccountsettingVM();
			BindingContext = vm;
		
			
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.GetUSerAccountdetails();
            MessagingCenter.Subscribe<Object, String>(this, "Profilepic", async (obj, item) =>
            {
                var i = item as String;
                this.setupProfilepicture(i);
            });
            
        }

        async void setupProfilepicture(string picurl)
        {
            try
            {
                var imagebytes = ImageService.DownlodaImage(picurl);
                ImageService.SavetoDisk("Profilepic", imagebytes);
                Profileimage.Source = ImageService.GetFromDisk("Profilepic");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");
            }
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                vm.MoveForwardtoEditProfiledetails(vm.Profiledetails);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", "Profile details not available", "OK");
            }
            
        }
    }
}

