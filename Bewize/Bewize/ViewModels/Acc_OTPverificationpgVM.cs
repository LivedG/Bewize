using System;
using Bewize.HelperResource;
using Bewize.Models;

using System.Windows.Input;
using Newtonsoft.Json;

namespace Bewize.ViewModels
{
	public class Acc_OTPverificationpgVM : BaseViewModel
	{
		public continewithOTPbtnCommand Continuebtn_Command { get; set; }
        public otp_backbtnCommand backbtn_Command { get; set; }

        private Verifyotp_reqPara _RequestPara_verifyotp { get; set; }
        public Verifyotp_reqPara RequestPara_verifyotp
        {
            get { return _RequestPara_verifyotp; }
            set
            {
                _RequestPara_verifyotp = value;
                OnPropertyChanged();
            }
        }

        private string _message { get; set; }
        public string message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public string _Firstchar { get; set; }
        public string FirstChar
        {
            get { return _Firstchar; }
            set
            {
                _Firstchar = value;
                OnPropertyChanged();
            }
        }

        public string _Secondchar { get; set; }
        public string Secondchar
        {
            get { return _Secondchar; }
            set
            {
                _Secondchar = value;
                OnPropertyChanged();
            }
        }

        public string _Thirdchar { get; set; }
        public string Thirdchar
        {
            get { return _Thirdchar; }
            set
            {
                _Thirdchar = value;
                OnPropertyChanged();
            }
        }
        public string _Fourthchar { get; set; }
        public string Fourthchar
        {
            get { return _Fourthchar; }
            set
            {
                _Fourthchar = value;
                OnPropertyChanged();
            }
        }

        public Acc_OTPverificationpgVM()
        {
            Continuebtn_Command = new continewithOTPbtnCommand(this);
            backbtn_Command = new otp_backbtnCommand(this);

        }

        public void MoveForwardtoMAtchOTP()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Profile.Acc_ResetpwdPage());
        }

        public async void VerifyOtp_continuebtnActionAsync()
        {
            try
            {

                string webURL = APIHelper.Verifyotp;
                HttpHelper httpHelper = new HttpHelper();
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(RequestPara_verifyotp));

                if (res.success)
                {
                    string otp = JsonConvert.SerializeObject(res.otp);
                    App.Current.MainPage.Navigation.PushAsync(new Views.Profile.Acc_ResetpwdPage());

                }
                else
                {
                    message = res.message;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }
        }


        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public void setup_otpstring(string otp)
        {

            var otpstring = otp.ToCharArray();
            this.FirstChar = otpstring[0].ToString();
            this.Secondchar = otpstring[1].ToString();
            this.Thirdchar = otpstring[2].ToString();
            this.Fourthchar = otpstring[3].ToString();
        }
    }


    public class continewithOTPbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Acc_OTPverificationpgVM VM;

        public continewithOTPbtnCommand(Acc_OTPverificationpgVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.VerifyOtp_continuebtnActionAsync();
        }
    }

    public class otp_backbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Acc_OTPverificationpgVM VM;

        public otp_backbtnCommand(Acc_OTPverificationpgVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveBackwardScreen();
        }

    }
}

