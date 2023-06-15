using System;
using System.Windows.Input;
using Bewize.Views;
using Bewize.Models;
using Bewize.HelperResource;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Bewize.ViewModels
{
	public class SignupwithEmailpageVM : BaseViewModel
    {
      //  public CreateaccountbtnCommand create_accountcmd { get; set; }
        public registerbackbtnCommand backbtn_cmd { get; set; }
        public MovetoLoginCommand logincmd { get; set; }

        public Registeruserbyemail _newuser { get; set; }
        public Registeruserbyemail Newuser
        {
            get { return _newuser; }
            set
            {
                _newuser = value;
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
 
        public SignupwithEmailpageVM()
		{
          //  create_accountcmd = new CreateaccountbtnCommand(this);
            backbtn_cmd = new registerbackbtnCommand(this);
            logincmd = new MovetoLoginCommand(this);
            Newuser = new Registeruserbyemail();
		}


        public async void Register_newuser(Registeruserbyemail userdetails)
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
                    App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());
                }
                else
                {
                      message = res.message;
                     await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                    MessagingCenter.Send<Object, string>(this, "RegistrationStatus", false.ToString());

                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", message, "OK");
            }
        }

        public async void GetUSerAccountdetails()
        {

            try
            {

                string webURL = APIHelper.Getuserdetailsbyid;
                HttpHelper httpHelper = new HttpHelper();

                APIResponse res = await httpHelper.callAPI(webURL, "");

                if (res.success)
                {
                    App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");
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
                this.GetUSerAccountdetails();
                if (udetails.profile_img != "" && udetails.profile_img != null)
                {
                   
                    MessagingCenter.Send<object, string>(this, "ProfilepicisSaved", "Profilepic");
                }
            }
        }



        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public void MoveForwardSigninwithMail()
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        public void MoveForwardSignwithMail()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Home.WelcomePage_());
        }
    }


    public class registerbackbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SignupwithEmailpageVM VM;

        public registerbackbtnCommand(SignupwithEmailpageVM vm)
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


    public class MovetoLoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SignupwithEmailpageVM VM;

        public MovetoLoginCommand(SignupwithEmailpageVM vm)
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
}

