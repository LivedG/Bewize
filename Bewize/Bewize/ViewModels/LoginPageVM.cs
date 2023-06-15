using System;
using System.Windows.Input;
using Bewize.Views;
using Bewize.Views.Signup_Login;
using Bewize.Models;
using Bewize.HelperResource;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Services;
using System.Numerics;
using System.Xml.Linq;

namespace Bewize.ViewModels
{
    public class LoginPageVM : BaseViewModel
    {
      
        public LoginwithMailCommand LoginwithMail_command { get; set; }
        public LoginwithAppleCommand LoginwithApple_Command { get; set; }
        public LoginwithGoogleCommand LoginwithGoogle_Command { get; set; }
        public LoginBackbtnCommand LoginBackbtn_Command { get; set; }
        public SignupCommand Signup_command { get; set; }
        public ForgetpwdlblCommand forgetlblTap_command { get; set; }
        public VisiblepwdCommand pwdVisible_cmd { get; set; }
        public UserDetails _usersdetails { get; set; }
        public UserDetails userDetails
        {
            get { return _usersdetails; }
            set
            {
                _usersdetails = value;
                OnPropertyChanged();
            }
        }

        public string _Loginid { get; set; }
        public string Loginid
        {
            get { return _Loginid; }
            set
            {
                 _Loginid = value;
                OnPropertyChanged();
            }
        }

        public string _Password { get; set; }
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }

        public Users_reqPara _user { get; set; }
        public Users_reqPara user
        {
            get { return _user; }
            set {
                _user = value;
                OnPropertyChanged();
            }
        }

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

        private bool _isActivity { get; set; }

        public bool isActivity
        {
            get { return _isActivity; }
            set
            {
                _isActivity = value;
                OnPropertyChanged();
            }
        }

        private string _message { get; set; }
        public string message
        {
            get
            { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }


        public LoginPageVM()
        {
            LoginwithMail_command = new LoginwithMailCommand(this);
            LoginwithGoogle_Command = new LoginwithGoogleCommand(this);
            LoginwithApple_Command = new LoginwithAppleCommand(this);
            LoginBackbtn_Command = new LoginBackbtnCommand(this);
            Signup_command = new SignupCommand(this);
            forgetlblTap_command = new ForgetpwdlblCommand(this);
         
            pwdVisible_cmd = new VisiblepwdCommand(this);
         
        }

       

        public void MoveForwardSigninwithMail()
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public void MoveForwardSigninwithGoogle()
        {
            App.Current.MainPage.Navigation.PushAsync(new SigninPage());
        }

        public void MoveForwardSigninwithApple()
        {
            App.Current.MainPage.Navigation.PushAsync(new SigninPage());
        }
        public void MoveForwardToSignup()
        {
            App.Current.MainPage.Navigation.PushAsync(new SignupPage());
        }

        public async Task MoveForwardToSigninProcessAsync(Users_reqPara userdetails)
        {

            try
            {
               // if (this.selectedCountry != null) { this.user.country_code = this.selectedCountry.country_code; }
                string webURL = APIHelper.loginAPI;
                HttpHelper httpHelper = new HttpHelper();
                isActivity = true;
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(userdetails));
                isActivity = false;
                if (res.success)
                {
                   UserDetails details = new UserDetails();
                   string obj = JsonConvert.SerializeObject(res.data);
                   details = JsonConvert.DeserializeObject<UserDetails>(obj);
                   this.StoreusertoLocaldb(details,res.token);
                   await App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());
                }
                else
                {
                    message = res.message;
                    isActivity = false;
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");

                }
            }
            catch (Exception ex)
            {
                isActivity = false;
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");
            }
        }

        public async void CountrycodeselectionAsync()
        {
            var countrypopuppage = new CountyCodeSelectionPage();
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

        public void MoveForwardForgetpwdprocess()
        {
            if (Loginid != null && Loginid != "") {
                Preferences.Set("Loginid", Loginid);
            }
            App.Current.MainPage.Navigation.PushAsync(new PwdVerificationPage());
        }

        public  async void StoreusertoLocaldb(UserDetails udetails,string token)
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
                    else {
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
                if (udetails.profile_img != "" && udetails.profile_img != null)
                {
                   
                    MessagingCenter.Send<object, string>(this, "Profilepic", udetails.profile_img);
                }
                
            }
        }

        
    }


    public class VisiblepwdCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginPageVM VM;

        public VisiblepwdCommand(LoginPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
          //  VM.VisiblePasswordtxt();
        }

    }


    public class LoginwithMailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginPageVM VM;

        public LoginwithMailCommand(LoginPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardSigninwithMail();
        }

    }

    

    public class LoginwithGoogleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginPageVM VM;

        public LoginwithGoogleCommand(LoginPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardToSigninProcessAsync(VM.user);
        }

    }

    public class LoginwithAppleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginPageVM VM;

        public LoginwithAppleCommand(LoginPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardToSigninProcessAsync(VM.user);
        }

    }


    public class SignupCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginPageVM VM;

        public SignupCommand(LoginPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardToSignup();
        }

    }

    public class LoginBackbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginPageVM VM;

        public LoginBackbtnCommand(LoginPageVM vm)
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


    public class ForgetpwdlblCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private LoginPageVM VM;

        public ForgetpwdlblCommand(LoginPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardForgetpwdprocess();
        }

    }


}