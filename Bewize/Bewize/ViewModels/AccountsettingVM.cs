using System;
using System.Windows.Input;
using Bewize.Views;
using Bewize.Models;
using Bewize.ViewModels;
using Bewize.HelperResource;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Bewize.ViewModels
{
	public class AccountsettingVM : BaseViewModel
	{
        public ChangepwdbtnCommand Changepwd_command { get; set; }
        public ClosebtnCommand Closebtn_Command { get; set; }
        public bool isCurrentloctionempty = true;

        public Users_reqPara _user { get; set; }
        public Users_reqPara user
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        private UserDetails _profiledetails { get; set; }
        public UserDetails Profiledetails
        {
            get { return _profiledetails; }
            set
            {
                _profiledetails = value;
                OnPropertyChanged();
            }
        }

        public AccountsettingVM()
		{
             Changepwd_command = new ChangepwdbtnCommand(this);
            Closebtn_Command = new ClosebtnCommand(this);
            Profiledetails = new UserDetails();
            _profiledetails = new UserDetails();
        }

        
        public void MoveForwardtoChangepwd()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Profile.Acc_NumberverificationPage());
        }


        public void MoveBackwardScreen()
        {
            if (isCurrentloctionempty == false)
            {
                App.Current.MainPage.Navigation.PushAsync(new Views.Home.MyHomepage());
            }  else {
                App.Current.MainPage.Navigation.PushAsync(new Views.Home.MyLocationHomepage());
            }
        }

        public async void GetUSerAccountdetails() {

            try {

                string webURL = APIHelper.Getuserdetailsbyid;
                HttpHelper httpHelper = new HttpHelper();
               
                APIResponse res = await httpHelper.callAPI(webURL,"");

                if (res.success)
                {
                    UserDetails details = new UserDetails();
                    string obj = JsonConvert.SerializeObject(res.data);
                    details = JsonConvert.DeserializeObject<UserDetails>(obj);
                    this.StoreusertoLocaldb(details, res.token);
                    this.Profiledetails = details;
                    this._profiledetails = details;
                }
                else {
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
            }
            catch (Exception ex) {

                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");
            }


        }

        public void MoveForwardtoEditProfiledetails(UserDetails udetails)
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Profile.EditAccountDetailspage(udetails));
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

              //  Preferences.Set("Token", token);
                if (udetails.phone != "" && udetails.phone != null) { 
                    Preferences.Set("user_phonenumber", udetails.phone);
                }
                if (udetails.country_code != "" && udetails.country_code != null){
                    Preferences.Set("user_countrycode", udetails.country_code);
                }
                if (udetails.email != "" && udetails.email != null) {
                    Preferences.Set("user_email", udetails.email);
                }
                if (udetails.profile_img != "" && udetails.profile_img != null)
                {
                    MessagingCenter.Send<object, string>(this, "Profilepic", udetails.profile_img);
                }

            }
        }


    }

    public class ChangepwdbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private AccountsettingVM VM;

        public ChangepwdbtnCommand(AccountsettingVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardtoChangepwd();
        }
    }

    public class ClosebtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private AccountsettingVM VM;

        public ClosebtnCommand(AccountsettingVM vm)
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

