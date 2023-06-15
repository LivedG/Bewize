using System;
using System.IO;
using System.Windows.Input;
using SQLite;
using Bewize.Models;
using Xamarin.Forms;
using Bewize.Views.Signup_Login;
using System.Linq;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace Bewize.ViewModels
{
	public class MenupageVM : BaseViewModel
	{
        public MyAccountsettingCommand Accountsetting_command { get; set; }
        public MyRatingCommand myRating_Command { get; set; }
        public SignOutbtnCommand signout_command { get; set; }
        public DissmissCommand Close_command { get; set; }



        public UserDetails _profiledetails { get; set; }
        public UserDetails Profiledetails
        {
            get { return _profiledetails; }
            set
            {
                _profiledetails = value;
                OnPropertyChanged();
            }
        }

        public MenupageVM()
		{
            signout_command = new SignOutbtnCommand(this);
            Close_command = new DissmissCommand(this);
            Accountsetting_command = new MyAccountsettingCommand(this);
            myRating_Command = new MyRatingCommand(this);
           //this.GetProfiledatafromlocalStorage();
        }

        public void MovetoSignupOptions()
        {
           // App.Current.MainPage.Navigation.PushAsync(new SignupPage());
        }


        public async void GetProfiledatafromlocalStorage()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var userList = await App.SQLiteDb.GetItemsAsync();

                if (userList.Count > 0)
                {
                     this.Profiledetails = userList.Last();
                    if (Profiledetails.profile_img != "" && Profiledetails.profile_img != null)
                    {
                        MessagingCenter.Send<object, string>(this, "Profilepic", Profiledetails.profile_img);
                    }
                }
                else {

                    await App.Current.MainPage.DisplayAlert("", "Please fill your acccount details for better experience.", "OK");

                }
            }

        }

        public async void User_Signout()
        {
            FileInfo fi = new FileInfo(App.DatabaseLocation);
            try
            {
                Preferences.Clear();
                var deleterows =  await App.SQLiteDb.DeleteAllItemAsync();
               
                App.Current.MainPage = new NavigationPage(new Views.Signup_Login.MainPage_());
                App.Current.MainPage.Navigation.PopToRootAsync();

            }
            catch (Exception ex)
            {
                fi.Delete();
            }
            
        }

        public void MovetoLoginOptions()
        {
            //App.Current.MainPage.Navigation.PushAsync(new SigninPage());
        }

        public void MovetoMasterview()
        {
            App.Current.MainPage.Navigation.PopAsync();

        }



        public class DissmissCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private MenupageVM VM;

            public DissmissCommand(MenupageVM vm)
            {
                VM = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                VM.MovetoMasterview();
            }

        }


        public class MyAccountsettingCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private MenupageVM VM;

            public MyAccountsettingCommand(MenupageVM vm)
            {
                VM = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                
            }

        }


        public class MyRatingCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private MenupageVM VM;

            public MyRatingCommand(MenupageVM vm)
            {
                VM = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {

            }

        }

        public class SignOutbtnCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private MenupageVM VM;

            public SignOutbtnCommand(MenupageVM vm)
            {
                VM = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                VM.User_Signout();
            }
        }

    }
}

