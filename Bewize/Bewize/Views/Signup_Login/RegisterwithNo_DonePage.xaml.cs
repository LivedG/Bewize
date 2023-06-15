using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views.Signup_Login
{	
	public partial class RegisterwithNo_DonePage : ContentPage
	{
		RegisterwithNo_DoneVM VM;

		public RegisterwithNo_DonePage ()
		{
			InitializeComponent ();
			VM = new RegisterwithNo_DoneVM();
			BindingContext = VM;
		}

        void Donebtn_Clicked(System.Object sender, System.EventArgs e)
        {
			VM.registrationsuccessfullywithPhonenumber();
        }
    }
}

