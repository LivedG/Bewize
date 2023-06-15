using System;
using System.Windows.Input;
using Bewize.Models;
using Bewize.Views.Signup_Login;
using Rg.Plugins.Popup.Services;
using Bewize.HelperResource;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Bewize.ViewModels
{
    public class SignupwithnumberVM : BaseViewModel
    {
        public Reg_numberbackbtnCommand backbtn_cmd { get; set; }
        public RegisterwithnumberCommand Registercmd { get; set; }
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
        public Registeruserbynumber _newuser { get; set; }
        public Registeruserbynumber Newuser
        {
            get { return _newuser; }
            set
            {
                _newuser = value;
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

        public SignupwithnumberVM()
        {
            Registercmd = new RegisterwithnumberCommand(this);
            backbtn_cmd = new Reg_numberbackbtnCommand(this);
            Loginid = new Sendotp_reqPara();
            RequestPara_verifyotp = new Verifyotp_reqPara();

           
        }

        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();

        }

        public void MoveForwardSigninwithnumber()
        {
            //    App.Current.MainPage.Navigation.PushAsync(new Signup_ReceivedotpPage());
           
        }

        public async void Register_newuser(Registeruserbynumber userdetails)
        {
            try
            {
                this.Newuser = userdetails;
                string webURL = APIHelper.RegisterAPI;
                HttpHelper httpHelper = new HttpHelper();

                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(userdetails));

                if (res.success)
                {
                    UserDetails details = new UserDetails();
                    string obj = JsonConvert.SerializeObject(res.data);
                    details = JsonConvert.DeserializeObject<UserDetails>(obj);
                    this.StoreusertoLocaldb(details, res.token);
                    //App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());
             
                }
                else
                {
                    message = res.message;
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", message, "OK");
            }
        }
        
        public async void StoreusertoLocaldb(UserDetails udetails, string token)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //Get All Persons  
                var userList = await App.SQLiteDb.GetItemsAsync();
                if (userList.Count <= 0)
                {
                    await App.SQLiteDb.SaveItemAsync(udetails);

                }
                else
                {
                    
                    var localuser = await App.SQLiteDb.GetItemAsync(udetails._id);
                    if (localuser != null)
                    {
                        await App.SQLiteDb.UpdateItemAsync(udetails);
                    }
                    else
                    {
                        await App.SQLiteDb.DeleteAllItemAsync();
                        await App.SQLiteDb.SaveItemAsync(udetails);
                    }
                }

                
                Preferences.Set("Token", token);
                if (udetails.phone != "" && udetails.phone != null)
                {
                    Preferences.Set("user_phonenumber", udetails.phone);
                }
                if (udetails.country_code != "" && udetails.country_code != null)
                {
                    Preferences.Set("user_countrycode", udetails.country_code);
                }
                if (udetails.email != "" && udetails.email != null)
                {
                    Preferences.Set("user_email", udetails.email);
                }
                this.SentOtp_continuebtnActionAsync();
                if (udetails.profile_img != "" && udetails.profile_img != null)
                {
                    MessagingCenter.Send<object, string>(this, "Profilepic", udetails.profile_img);

                }
            }
        }


        public async void CountrycodeselectionAsync()
        {
            await PopupNavigation.Instance.PushAsync(new Views.Signup_Login.CountyCodeSelectionPage());
        }

        public async void SentOtp_continuebtnActionAsync()
        {
            try
            {

                string webURL = APIHelper.SendOTP;
                HttpHelper httpHelper = new HttpHelper();

                var countrycode = Preferences.Get("user_countrycode", "");
                var phone = Preferences.Get("user_phonenumber", "");
                this.Loginid = new Sendotp_reqPara();
                Loginid.country_code = countrycode;
                Loginid.phone = phone;
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(Loginid));

                if (res.success)
                {
                    // var otp = JsonConvert.DeserializeObject(res.data.ToString());
                    var Obj = JsonConvert.DeserializeObject<Verifyotp_reqPara>(res.data.ToString());
                    this.RequestPara_verifyotp.otp = Obj.otp;
                    this.RequestPara_verifyotp.phone = Obj.phone;
                    App.Current.MainPage.Navigation.PushAsync(new Views.Signup_Login.Signup_ReceivedotpPage(RequestPara_verifyotp));

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

      

    }
    public class Reg_numberbackbtnCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private SignupwithnumberVM VM;

            public Reg_numberbackbtnCommand(SignupwithnumberVM vm)
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


    public class RegisterwithnumberCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SignupwithnumberVM VM;

        public RegisterwithnumberCommand(SignupwithnumberVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardSigninwithnumber();
        }

    }
}

