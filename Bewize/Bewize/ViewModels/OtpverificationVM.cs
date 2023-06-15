using System;
using System.Windows.Input;
using Bewize.Models;
using Bewize.HelperResource;
using Bewize.Views;
using Newtonsoft.Json;

namespace Bewize.ViewModels
{
	public class OtpverificationVM : BaseViewModel
	{
        public otp_BackbtnCommand otpbackbtn_command { get; set; }
        public otp_ContinuebtnCommand otpcontinuebtn_command { get; set; }

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
        
        public OtpverificationVM()
		{
            otpbackbtn_command = new otp_BackbtnCommand(this);
            otpcontinuebtn_command = new otp_ContinuebtnCommand(this);
           
        }

        public OtpverificationVM(string otpstring)
        {
            otpbackbtn_command = new otp_BackbtnCommand(this);
            otpcontinuebtn_command = new otp_ContinuebtnCommand(this);
            this.setup_otpstring(otpstring);
        }



        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public void MoveForwardResetpwdprocess()
        {
           // App.Current.MainPage.Navigation.PushAsync(new ResetpwdPage());
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
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");

                    App.Current.MainPage.Navigation.PushAsync(new Views.ResetpwdPage(this.RequestPara_verifyotp));

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");

                    message = res.message;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");

            }
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

    public class otp_BackbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private OtpverificationVM VM;

        public otp_BackbtnCommand(OtpverificationVM vm)
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


    public class otp_ContinuebtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private OtpverificationVM VM;

        public otp_ContinuebtnCommand(OtpverificationVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardResetpwdprocess();
        }
    }

}

