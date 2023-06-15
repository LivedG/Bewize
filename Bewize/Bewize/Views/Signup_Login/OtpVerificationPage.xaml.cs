using System;
using System.Collections.Generic;
using Bewize.Models;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views
{	
	public partial class OtpVerificationPage : ContentPage
	{

        
       
        OtpverificationVM vm;

		//public OtpVerificationPage ()
		//{
		//	InitializeComponent ();
		//	vm = new OtpverificationVM();
		//	BindingContext = vm;
		//}

        public OtpVerificationPage(Verifyotp_reqPara Para)
        {
            InitializeComponent();
            vm = new OtpverificationVM();
            vm.setup_otpstring(Para.otp);
            vm.RequestPara_verifyotp = Para;
            BindingContext = vm;
       
        }

        public void continuebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            vm.VerifyOtp_continuebtnActionAsync();
        }

        
    }
}

