using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Xamarin.Forms;
using Bewize.Models;
using System.ComponentModel;

namespace Bewize.Views.Signup_Login
{	
	public partial class Loginbynumber : ContentPage, INotifyPropertyChanged
    {
        public LoginPageVM vm;

        //private Country _SelectedCountry { get; set; }
        //public Country SelectedCountry
        //{
        //    get { return _SelectedCountry; }
        //    set   { _SelectedCountry = value;  }
        //}


        public Loginbynumber ()
		{
			InitializeComponent ();
            vm = new LoginPageVM();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Object, Country>(this, "selectedcountry", async (obj, item) =>
            {
                var i = item as Country;
                vm.selectedCountry = i;

            });
        }


        public void Showpwdbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (pwdtxt.IsPassword == true)
            {
                pwdtxt.IsPassword = false;
                Showpwdbtn.Source = "hideenEye.png";
            }
            else
            {
                pwdtxt.IsPassword = true;
                Showpwdbtn.Source = "Eye.png";
            }
        }

        public async void Loginbtn_Clicked(System.Object sender, System.EventArgs e)
        {

            if (pnumbertxt.Text != null && Countrycodetxt.Text != null && pwdtxt != null && pnumbertxt.Text.Length == 10)
            {
                if (pwdtxt.Text.Length < 8)
                {
                    await App.Current.MainPage.DisplayAlert("", "The password you entered is not valid.", "OK");
                    pwdtxt.Text = string.Empty;
                    Countrycodetxt.Text = string.Empty;
                    pnumbertxt.Text = string.Empty;
                }
                else
                {
                    var UsersreqPara = new Users_reqPara();
                    UsersreqPara.country_code = this.vm.selectedCountry.country_code;
                    UsersreqPara.phone = pnumbertxt.Text;
                    UsersreqPara.password = pwdtxt.Text;

                    vm.MoveForwardToSigninProcessAsync(userdetails: UsersreqPara);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", "The number or password you entered is not valid.", "OK");
                pwdtxt.Text = string.Empty;
                Countrycodetxt.Text = string.Empty;
                pnumbertxt.Text = string.Empty;
            }
        }

        public void googlesignbtn_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        public void Applesignbtn_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        public void CustomEntry_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            vm.CountrycodeselectionAsync();
        }
    }
}

