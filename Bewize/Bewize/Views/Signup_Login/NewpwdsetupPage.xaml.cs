using System;
using System.Collections.Generic;
using Bewize.Models;
using Bewize.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Bewize.Views.Signup_Login
{	
	public partial class NewpwdsetupPage : ContentPage
	{
		NewpwdVM VM;

		public NewpwdsetupPage ()
		{
			InitializeComponent ();
			VM = new NewpwdVM();
			BindingContext = VM;

		}

		public async void Confirmpwdbtn_Clicked(System.Object sender, System.EventArgs e)
		{
			if (newpwdtxt.Text == "" || confirmpwdtxt.Text == "")
			{

				await App.Current.MainPage.DisplayAlert("", "Please enter valid data.", "OK");

			}
			else if (newpwdtxt.Text != confirmpwdtxt.Text)
			{

				await App.Current.MainPage.DisplayAlert("Oops", "Both passwords are not match.", "OK");

			}
			else {
				if (newpwdtxt.Text == confirmpwdtxt.Text)
				{

                    var countrycode = Preferences.Get("user_countrycode", "");
                    var phone = Preferences.Get("user_phonenumber", "");

                    var newpwd = new Forgetpassword_reqpara();
                    newpwd.password = newpwdtxt.Text;
                    if (phone != "" && phone != null)
                    {
                        newpwd.phone = phone;
                        if (phone != "" && phone != null) { newpwd.country_code = countrycode; }
                        VM.SetupPassword_CompletedRegistration(newpwd);
                    }
                    else {
                        await App.Current.MainPage.DisplayAlert("Oops", "Could not found required data!.", "OK");
                    }
                }
            }

            
        }

        public void Showpwdiconbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (confirmpwdtxt.IsPassword == true)
            {
                confirmpwdtxt.IsPassword = false;
                Showpwdiconbtn.Source = "hideenEye.png";
            }
            else
            {
                confirmpwdtxt.IsPassword = true;
                Showpwdiconbtn.Source = "Eye.png";
            }
        }

        public void pwdShowbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (newpwdtxt.IsPassword == true)
            {
                newpwdtxt.IsPassword = false;
                pwdShowbtn.Source = "hideenEye.png";
            }
            else
            {
                newpwdtxt.IsPassword = true;
                pwdShowbtn.Source = "Eye.png";
            }
        }
    }
}

