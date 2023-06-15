using System;
using System.Diagnostics;
using System.Windows.Input;
using Bewize.HelperResource;
using Bewize.Models;
using Bewize.ViewModels;
using Bewize.Views;
using Newtonsoft.Json;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Bewize.ViewModels
{
	public class SignupPageVM
	{
        public SignupwithMailCommand SignupwithMail_command { get; set; }
        public SignupwithnumberCommand Signupwithnumber_command { get; set; }
        public SignupwithAppleCommand SignupwithApple_Command { get; set; }
        public SignupwithGoogleCommand SignupwithGoogle_Command { get; set; }
        public BackbtnCommand Backbtn_Command { get; set; }
        IGoogleClientManager _googleService = CrossGoogleClient.Current;


        public SignupPageVM()
		{
            SignupwithMail_command = new SignupwithMailCommand(this);
            Signupwithnumber_command = new SignupwithnumberCommand(this);
            SignupwithGoogle_Command = new SignupwithGoogleCommand(this);
            SignupwithApple_Command = new SignupwithAppleCommand(this);
            Backbtn_Command = new BackbtnCommand(this);
		}

        public void MoveForwardSignupwithMail()
        {
            App.Current.MainPage.Navigation.PushAsync(new SignupwithEmailPage());
        }

        public void MoveForwardSignupwithGoogle()
        {
            LoginAsync();
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
                            this.GetAccesstokendetails(details);
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

                    MessagingCenter.Send<object, string>(this, "ProfilepicisSaved", "Profilepic");
                }
            }

        }

        public async void GetAccesstokendetails(UserDetails udetails)
        {
            try
            {
                var requestPara = new Registeruserbyemail();
                requestPara.email = udetails.email;
                requestPara.fname = udetails.fname;
                requestPara.lname = udetails.lname;
                requestPara.username = udetails.username;
                string webURL = APIHelper.ThirdpartyUserRegister;
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

        public void MoveForwardSignupwithApple()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());
        }

        public void MoveForwardSignupwithnumber()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Signup_Login.SignupWithnumberPage());
        }

        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}

public class SignupwithMailCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private SignupPageVM VM;

    public SignupwithMailCommand(SignupPageVM vm)
    {
        VM = vm;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        VM.MoveForwardSignupwithMail();
    }

}
public class SignupwithnumberCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private SignupPageVM VM;

    public SignupwithnumberCommand(SignupPageVM vm)
    {
        VM = vm;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        VM.MoveForwardSignupwithnumber();
    }

}

public class SignupwithGoogleCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private SignupPageVM VM;

    public SignupwithGoogleCommand(SignupPageVM vm)
    {
        VM = vm;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        VM.MoveForwardSignupwithGoogle();
    }

}

public class SignupwithAppleCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private SignupPageVM VM;

    public SignupwithAppleCommand(SignupPageVM vm)
    {
        VM = vm;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        VM.MoveForwardSignupwithApple();
    }  

}


public class BackbtnCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    private SignupPageVM VM;

    public BackbtnCommand(SignupPageVM vm)
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
