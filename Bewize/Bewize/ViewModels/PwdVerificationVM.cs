using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Bewize.Models;
using Bewize.Views;
using Rg.Plugins.Popup.Services;
using Bewize.HelperResource;
using Newtonsoft.Json;


namespace Bewize.ViewModels
{
	public class PwdVerificationVM : BaseViewModel
	{
       public Pwd_VerificationBackbtnCommand pwdbackbtn_command { get; set; }
       public countrycodeselectioncmd countrycodeselect_cmd { get; set; }

        private Country _SelectedCountry;
        public Country selectedCountry
        {
            get {  return _SelectedCountry;  }
            set {
                _SelectedCountry = value;
                OnPropertyChanged();
            }
        }

        public Sendotp_reqPara _loginid { get; set; }
        public Sendotp_reqPara Loginid
        {
            get { return _loginid; }
            set {
                _loginid = value;
                OnPropertyChanged();
            }
        }

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
            get  { return _message; }
            set  {
                _message = value;
                OnPropertyChanged();
            }
        }


        public PwdVerificationVM()
        {
            pwdbackbtn_command = new Pwd_VerificationBackbtnCommand(this);
//countrycodeselect_cmd = new countrycodeselectioncmd(this);
            RequestPara_verifyotp = new Verifyotp_reqPara();
          

        }
         public void MoveBackwardScreen()
         {
                App.Current.MainPage.Navigation.PopAsync();
         }


        public async void SentOtp_continuebtnActionAsync()
        {
            try
            {

                string webURL = APIHelper.SendOTP;
                HttpHelper httpHelper = new HttpHelper();
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(Loginid));
               
                if (res.success)
                {
                    //string otp = JsonConvert.SerializeObject(res.data);
                    //this.RequestPara_verifyotp.otp = res.otp;
                    //this.RequestPara_verifyotp.phone = (string)res.data;
                    Verifyotp_reqPara details = new Verifyotp_reqPara();
                    string obj = JsonConvert.SerializeObject(res.data);
                    details = JsonConvert.DeserializeObject<Verifyotp_reqPara>(obj);

                    this.RequestPara_verifyotp.otp = details.otp;
                    this.RequestPara_verifyotp.country_code = this.Loginid.country_code;
                    this.RequestPara_verifyotp.phone = details.phone;
                    // otp_Page = new OtpVerificationPage(RequestPara_verifyotp);
                    App.Current.MainPage.Navigation.PushAsync(new Views.OtpVerificationPage(RequestPara_verifyotp));

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

        public async void CountrycodeselectionAsync()
        {
            await PopupNavigation.Instance.PushAsync(new Views.Signup_Login.CountyCodeSelectionPage());
        }

        public async void SetupSelectedcountycode(Country _selectedcountry) {
            this.selectedCountry = _selectedcountry;
        }


        public async void ClosePopup()
        {
            await PopupNavigation.Instance.PopAsync();
        }

    }


    public class countrycodeselectioncmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private PwdVerificationVM VM;

        public countrycodeselectioncmd(PwdVerificationVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.CountrycodeselectionAsync();
        }
    }


    public class Pwd_VerificationBackbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private PwdVerificationVM VM;

        public Pwd_VerificationBackbtnCommand(PwdVerificationVM vm)
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

