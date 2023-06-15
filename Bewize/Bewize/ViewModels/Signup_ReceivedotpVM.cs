using System;
using System.Windows.Input;
using Bewize.Views.Signup_Login;
using Bewize.Models;
using Bewize.HelperResource;
using Newtonsoft.Json;

namespace Bewize.ViewModels
{
	public class Signup_ReceivedotpVM : BaseViewModel
	{
        private string message;

        public Received_otpbackbtnCommand backbtn_cmd { get; set; }
        public VerifyReceivedotpCommand Verifyotpcmd { get; set; }


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

        public Signup_ReceivedotpVM()
		{

           Verifyotpcmd = new VerifyReceivedotpCommand(this);
            backbtn_cmd = new Received_otpbackbtnCommand(this);
        }

        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public void VerifyReceivedotp()
        {
            this.VerifyOtp_ActionAsync();
        }

        public void setup_otpstring(string otp)
        {

            var otpstring = otp.ToCharArray();
            this.FirstChar = otpstring[0].ToString();
            this.Secondchar = otpstring[1].ToString();
            this.Thirdchar = otpstring[2].ToString();
            this.Fourthchar = otpstring[3].ToString();
        }


        public async void VerifyOtp_ActionAsync()
        {
            try
            {

                string webURL = APIHelper.Verifyotp;
                HttpHelper httpHelper = new HttpHelper();
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(RequestPara_verifyotp));

                if (res.success)
                {
                    // string otp = JsonConvert.SerializeObject(res.otp);
                    //this.setup_otpstring(otp);
                    await App.Current.MainPage.DisplayAlert("Otp verify successfully.", message, "OK");

                   App.Current.MainPage.Navigation.PushAsync(new Views.Signup_Login.NewpwdsetupPage());

                }
                else
                {
                    message = res.message;
                    await App.Current.MainPage.DisplayAlert("", message, "OK");

                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");

            }
        }

        public class Received_otpbackbtnCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private Signup_ReceivedotpVM VM;

            public Received_otpbackbtnCommand(Signup_ReceivedotpVM vm)
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


        public class VerifyReceivedotpCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private Signup_ReceivedotpVM VM;

            public VerifyReceivedotpCommand(Signup_ReceivedotpVM vm)
            {
                VM = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                VM.VerifyReceivedotp();
            }

        }
    }
}

