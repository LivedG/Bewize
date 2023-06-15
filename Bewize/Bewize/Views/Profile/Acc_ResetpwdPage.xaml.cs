using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views.Profile
{	
	public partial class Acc_ResetpwdPage : ContentPage
	{

        Acc_ResetpwdVM VM;

		public Acc_ResetpwdPage ()
		{
			InitializeComponent ();
            VM = new Acc_ResetpwdVM();
            BindingContext = VM;
		}

        public void Showpwdiconbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            
            if (confirmpwdxt.IsPassword == true)
            {
                confirmpwdxt.IsPassword = false;
                pwdshowbtn2.Source = "hideenEye.png";
            }
            else
            {
                confirmpwdxt.IsPassword = true;
                pwdshowbtn2.Source = "Eye.png";
            }
        }

        public void pwdShowbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (pwdtxt.IsPassword == true)
            {
                pwdtxt.IsPassword = false;
                pwdShowbtn1.Source = "hideenEye.png";
            }
            else
            {
                pwdtxt.IsPassword = true;
                pwdShowbtn1.Source = "Eye.png";
            }
        }

        public async void Resetpwdbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (pwdtxt.Text != "" && confirmpwdxt.Text != "" && confirmpwdxt.Text == pwdtxt.Text)
            {
                VM.Sucessfullychangedpwd(pwdtxt.Text);

            }
            else {

                pwdtxt.Text = "";
                confirmpwdxt.Text = "";
                await App.Current.MainPage.DisplayAlert("","Enter valid password.", "OK");
            }
        }
    }
}

