using System;
using System.Collections.Generic;
using Bewize.Models;
using Xamarin.Forms;
using Bewize.ViewModels;

namespace Bewize.Views.Profile
{	
	public partial class Acc_OTPverificationPage : ContentPage
	{
        OtpverificationVM vm;

        public Acc_OTPverificationPage(Verifyotp_reqPara Para)
        {
            InitializeComponent();
            vm = new OtpverificationVM();
            vm.setup_otpstring(Para.otp);
            vm.RequestPara_verifyotp = Para;
            BindingContext = vm;

        }

        public void continuebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (vm.RequestPara_verifyotp.otp != null)
            {
                vm.VerifyOtp_continuebtnActionAsync();
            }
        }
    }
}

