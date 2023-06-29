using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Bewize.ViewModels;
using System.Net.Mail;
using System.Threading.Tasks;
using Bewize.Models;

namespace Bewize.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPageVM vm;
        public LoginPage()
        {
            InitializeComponent();
            vm = new LoginPageVM();
            BindingContext = vm;
        }

        void Showpwdbtn_Clicked(System.Object sender, System.EventArgs e)
        {
             if (pwdtxt.IsPassword == true)
            {
                pwdtxt.IsPassword = false;
                Showpwdbtn.Source = "hideenEye.png";
            }
            else {
                pwdtxt.IsPassword = true;
                Showpwdbtn.Source = "Eye.png";
            }
        }

        public async void Loginbtn_actionAsync(System.Object sender, System.EventArgs e)
        {

            if (Loginidtxt.Text != null && this.IsValid(Loginidtxt.Text) && pwdtxt != null && pwdtxt.Text.Length > 7)
            {
                  if (pwdtxt.Text.Length < 8)
                  {
                    await App.Current.MainPage.DisplayAlert("", "The password you entered is not valid.", "OK");
                    pwdtxt.Text = string.Empty;
                    Loginidtxt.Text = string.Empty;
                  }
                 else
                  {
                    var UsersreqPara = new Users_reqPara();
                    UsersreqPara.email = Loginidtxt.Text;
                    UsersreqPara.password = pwdtxt.Text;
                    vm.MoveForwardToSigninProcessAsync(userdetails: UsersreqPara);
                  }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", "The email or password you entered is not valid.", "OK");
                pwdtxt.Text = string.Empty;
                Loginidtxt.Text = string.Empty;
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
    }


}

