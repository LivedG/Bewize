using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Bewize.HelperResource;
using Bewize.Models;
using Bewize.Views;
using Bewize.Views.Home;
using Newtonsoft.Json;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Bewize.ViewModels
{
    public class SigninPageVM
    {
        public SigninwithMailCommand SigninwithMail_command { get; set; }
        public SigninwithNoCommand SigninwithNo_command { get; set; }
        public SigninwithAppleCommand SigninwithApple_Command { get; set; }
        public SigninwithGoogleCommand SigninwithGoogle_Command { get; set; }
        public SinginBackbtnCommand SinginBackbtn_Command { get; set; }
      //  public bool IsAppleSignInAvailable { get { return appleSignInService?.IsAvailable ?? false; } }
        public ICommand SignInWithAppleCommand { get; set; }

        public event EventHandler OnSignIn = delegate { };

       // IAppleSignInService appleSignInService;

        public bool IsLoggedIn { get; set; }

        public string Token { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        IGoogleClientManager _googleService = CrossGoogleClient.Current;

        public event PropertyChangedEventHandler PropertyChanged;

        public SigninPageVM()
        {
            SigninwithMail_command = new SigninwithMailCommand(this);
            SigninwithGoogle_Command = new SigninwithGoogleCommand(this);
            SigninwithApple_Command = new SigninwithAppleCommand(this);
            SinginBackbtn_Command = new SinginBackbtnCommand(this);
            SigninwithNo_command = new SigninwithNoCommand(this);
           // appleSignInService = DependencyService.Get<IAppleSignInService>();


           

            IsLoggedIn = false;
        }

        public void MoveForwardSigninwithMail()
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        public void MoveForwardSigninwithNumber()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Signup_Login.Loginbynumber());
        }

        public  void MoveForwardSigninwithGoogle()
        {
            // App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());
             this.LoginAsync();
        }

        public async void MoveForwardSigninwithApple()
        {
            //var account = await appleSignInService.SignInAsync();
            //if (account != null)
            //{
            //    UserDetails details = new UserDetails();
            //    details.email = account.Email;
            //    details.fname = account.Name;
            //    OnSignIn?.Invoke(this, default(EventArgs));
            //}
        }


        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }


        public async void LoginAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(_googleService.AccessToken))
                {
                    //Always require user authentication
                    _googleService.Logout();
                }

                EventHandler<GoogleClientResultEventArgs<GoogleUser>> userLoginDelegate = null;
                userLoginDelegate = async (object sender, GoogleClientResultEventArgs<GoogleUser> e) =>
                {
                    switch (e.Status)
                    {
                        case GoogleActionStatus.Completed:
                            UserDetails details = new UserDetails();
                            var googleUserString = JsonConvert.SerializeObject(e.Data);
                            details._id = e.Data.Id;
                            details.fname = e.Data.GivenName;
                            details.lname = e.Data.FamilyName;
                            details.profile_img = e.Data.Picture.ToString();
                            details.email = e.Data.Email;
                            details.username = e.Data.Name;
                            await Task.Run(() =>
                            {
                                this.GetAccesstokendetails(details);
                            });
                            Debug.WriteLine($"Google Logged in succesfully: {googleUserString}");
                            break;
                        case GoogleActionStatus.Canceled:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Canceled", "Ok");
                            break;
                        case GoogleActionStatus.Error:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Error", "Ok");
                            break;
                        case GoogleActionStatus.Unauthorized:
                            await App.Current.MainPage.DisplayAlert("Google Auth", "Unauthorized", "Ok");
                            break;
                    }

                    _googleService.OnLogin -= userLoginDelegate;
                };

                _googleService.OnLogin += userLoginDelegate;
                await _googleService.LoginAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        public async void StoreusertoLocaldb(UserDetails udetails, string token)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
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
                //this.GetUSerAccountdetails();
                if (udetails.profile_img != "" && udetails.profile_img != null)
                {

                    MessagingCenter.Send<object, string>(this, "ProfilepicisSaved", "Profilepic");
                }
            }

        }

        public async void GetAccesstokendetails(UserDetails udetails) {
            try
            {
                var requestPara = new EmailRequestPara();
                requestPara.email = udetails.email;

                string webURL = APIHelper.ThirdpartyUserLogin;
                HttpHelper httpHelper = new HttpHelper();
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(requestPara));

                if (res.success)
                {
                    UserDetails details = new UserDetails();
                    string obj = JsonConvert.SerializeObject(res.data);
                    details = JsonConvert.DeserializeObject<UserDetails>(obj);
                    this.StoreusertoLocaldb(details, res.token);
                    await App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());
                }
                else
                {
                   await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                    MessagingCenter.Send<Object, string>(this, "RegistrationStatus", false.ToString());

                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", ex.Message.ToString(), "OK");
            }
        }

    }


    public class SigninwithMailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SigninPageVM VM;

        public SigninwithMailCommand(SigninPageVM vm)
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


    public class SigninwithNoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SigninPageVM VM;

        public SigninwithNoCommand(SigninPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardSigninwithNumber();
        }

    }

    public class SigninwithGoogleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SigninPageVM VM;

        public SigninwithGoogleCommand(SigninPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardSigninwithGoogle();
        }

    }

    public class SigninwithAppleCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SigninPageVM VM;

        public SigninwithAppleCommand(SigninPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardSigninwithApple();
        }

    }


    public class SinginBackbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SigninPageVM VM;

        public SinginBackbtnCommand(SigninPageVM vm)
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
