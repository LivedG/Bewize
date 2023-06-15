using System;
using System.Collections.Generic;
using System.Net.Mail;
using Xamarin.Forms;
using Bewize.ViewModels;
using Bewize.Models;
using Bewize.HelperResource;

namespace Bewize.Views
{
    public partial class SignupwithEmailPage : ContentPage
    {
        SignupwithEmailpageVM VM;

        public SignupwithEmailPage()
        {
            InitializeComponent();
            VM = new SignupwithEmailpageVM();
            BindingContext = VM;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
         
            MessagingCenter.Subscribe<Object, string>(this, "RegistrationStatus", async (obj, item) =>
            {
                var i = item as string;
                if (i == "False")
                {
                    this.ClearregisterForm();
                }
            });

        }


        void ClearregisterForm()
        {
            pwrdtxt.Text = string.Empty;
            usernametxt.Text = string.Empty;
            Emailtxt.Text = string.Empty;
            Firstnametxt.Text = string.Empty;
            Lastnametxt.Text = string.Empty;
        }


        void Eyebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (pwrdtxt.IsPassword == true)
            {
                pwrdtxt.IsPassword = false;
                this.Eyebtn.Source = "hideenEye.png";
            }
            else {
                pwrdtxt.IsPassword = true;
                this.Eyebtn.Source = "Eye.png";
            }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public async void CreateAccountbtn_Clicked(System.Object sender, System.EventArgs e)
        {

            if (Firstnametxt.Text != null && Lastnametxt.Text != null && pwrdtxt.Text != null && usernametxt.Text != null && Emailtxt.Text != null)
            {
                if (pwrdtxt.Text.Length < 8)
                {
                    await App.Current.MainPage.DisplayAlert("", "The password you entered is not valid.", "OK");
                    pwrdtxt.Text = string.Empty;
                }
                else if (IsValid(Emailtxt.Text) == false)
                {
                    await App.Current.MainPage.DisplayAlert("", "The email you entered is not valid.", "OK");
                    Emailtxt.Text = string.Empty;
                }
                else
                {
                    VM.Register_newuser(VM.Newuser);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", "All fields are mandatory.", "OK");
                pwrdtxt.Text = string.Empty;
                usernametxt.Text = string.Empty;
                Emailtxt.Text = string.Empty;
                Firstnametxt.Text = string.Empty;
                Lastnametxt.Text = string.Empty;
            }

          //  VM.MoveForwardSignwithMail();
        }

      
    }
}

