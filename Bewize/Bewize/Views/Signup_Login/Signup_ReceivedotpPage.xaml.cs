using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Xamarin.Forms;
using Bewize.Models;

namespace Bewize.Views.Signup_Login
{	
	public partial class Signup_ReceivedotpPage : ContentPage
	{
		Signup_ReceivedotpVM VM;

        //public Signup_ReceivedotpPage (Verifyotp_reqPara requestPara_verifyotp)
        //{
        //	InitializeComponent ();
        //	VM = new Signup_ReceivedotpVM();
        //	BindingContext = VM;
        //}

        public Signup_ReceivedotpPage(Verifyotp_reqPara Para)
        {
            InitializeComponent();
            VM = new Signup_ReceivedotpVM();
            BindingContext = VM;
            VM.setup_otpstring(Para.otp);
            VM.RequestPara_verifyotp = Para;
            BindingContext = VM;

            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.VerifyOtp_ActionAsync();
        }



        void Continuebtn_Clicked_1(System.Object sender, System.EventArgs e)
        {
            VM.VerifyReceivedotp();
        }
    }
}

