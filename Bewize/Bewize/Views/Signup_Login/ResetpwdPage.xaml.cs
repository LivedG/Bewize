using System;
using System.Collections.Generic;
using Bewize.HelperResource;
using Bewize.Models;
using Bewize.ViewModels;
using Bewize.Views.Signup_Login;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Bewize.Views
{	
	public partial class ResetpwdPage : ContentPage
	{
		ResetpwdVM VM;

		//public ResetpwdPage ()
		//{
		//	InitializeComponent ();
		//	VM = new ResetpwdVM();
		//	BindingContext = VM;
		//}

        public ResetpwdPage(Verifyotp_reqPara Para)
        {
            InitializeComponent();
            VM = new ResetpwdVM();
            VM.RequestPara_verifyotp = Para;
            BindingContext = VM;

        }

        public async void Resetpwdbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (pwdtxt.Text == "" || confirmpwdtxt.Text == "")
            {

                await App.Current.MainPage.DisplayAlert("", "Please enter valid data.", "OK");

            }
            else if (pwdtxt.Text != confirmpwdtxt.Text)
            {

                await App.Current.MainPage.DisplayAlert("Oops", "Both passwords are not match.", "OK");

            }
            else
            {
                if (pwdtxt.Text == confirmpwdtxt.Text)
                {
                    var newpwd = new Users_reqPara();
                    newpwd.country_code = VM.RequestPara_verifyotp.country_code;
                    newpwd.phone = VM.RequestPara_verifyotp.phone;
                    newpwd.password = pwdtxt.Text;
                    if (Preferences.ContainsKey("Loginid")) {
                        var email = Preferences.Get("Loginid", "");
                        newpwd.email = email;
                    }
                    VM.MoveForwardResetpwdprocess(newpwd);
                }
            }
        }

        public void pwdShowbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (pwdtxt.IsPassword == true)
            {
                pwdtxt.IsPassword = false;
                pwdShowbtn.Source = "hideenEye.png";
            }
            else
            {
                pwdtxt.IsPassword = true;
                pwdShowbtn.Source = "Eye.png";
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
    }
}

