using System;
using Bewize.Models;
using Bewize.ViewModels;
using Bewize.HelperResource;
using System.Windows.Input;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;

namespace Bewize.ViewModels
{
	public class Acc_NumberverificationpgVM: BaseViewModel
	{
        public ContinuewithnumberbtnCommand AccContinuebtn_Command { get; set; }
        public Acc_backbtnCommand accbackbtn_Command { get; set; }


        private Country _SelectedCountry;
        public Country selectedCountry
        {
            get { return _SelectedCountry; }
            set
            {
                _SelectedCountry = value;
                OnPropertyChanged();
            }
        }


        private List<Country> _CountryList;
        public List<Country> CountryList
        {
            get { return _CountryList; }
            set
            {
                _CountryList = value;
                OnPropertyChanged();
            }
        }


        public Sendotp_reqPara _loginid { get; set; }
        public Sendotp_reqPara Loginid
        {
            get { return _loginid; }
            set
            {
                _loginid = value;
                OnPropertyChanged();
            }
        }


        private string _phoneNumber { get; set; }
        public string Phonenumber
        {
            get
            { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
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
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }


        public Acc_NumberverificationpgVM()
        {
            AccContinuebtn_Command = new ContinuewithnumberbtnCommand(this);
            accbackbtn_Command = new Acc_backbtnCommand(this);
            Loginid = new Sendotp_reqPara();
            RequestPara_verifyotp = new Verifyotp_reqPara();
          
        }

        public async void MoveForwardtoMAtchOTP()
        {
             try
                {

                    string webURL = APIHelper.SendOTP;
                    HttpHelper httpHelper = new HttpHelper();
                    Loginid.country_code = selectedCountry.country_code;
                    Loginid.phone = Phonenumber;
                    APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(Loginid));

                    if (res.success)
                    {
                          Verifyotp_reqPara details = new Verifyotp_reqPara();
                          string obj = JsonConvert.SerializeObject(res.data);
                         details = JsonConvert.DeserializeObject<Verifyotp_reqPara>(obj);
                    
                        this.RequestPara_verifyotp.otp = details.otp;
                        this.RequestPara_verifyotp.country_code = details.country_code;
                        this.RequestPara_verifyotp.phone = details.phone;
                        App.Current.MainPage.Navigation.PushAsync(new Views.Profile.Acc_OTPverificationPage(RequestPara_verifyotp));
                    //    App.Current.MainPage.Navigation.PushAsync(new Views.OtpVerificationPage(RequestPara_verifyotp));

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
            var countrypopuppage = new Views.Signup_Login.CountyCodeSelectionPage();
            countrypopuppage.SelectedCountrySet += this.OncountrySeletion;

            await PopupNavigation.Instance.PushAsync(countrypopuppage);
        }

        public void OncountrySeletion(object source, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("{0} ", selectedCountry);

            App.Current.MainPage.Navigation.PopAsync();
        }


        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }


    public class ContinuewithnumberbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Acc_NumberverificationpgVM VM;

        public ContinuewithnumberbtnCommand(Acc_NumberverificationpgVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardtoMAtchOTP();
        }
    }

    public class Acc_backbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Acc_NumberverificationpgVM VM;

        public Acc_backbtnCommand(Acc_NumberverificationpgVM vm)
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

