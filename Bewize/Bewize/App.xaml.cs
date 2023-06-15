using System;
using Xamarin.Forms;
using Bewize.Views.Signup_Login;
using Bewize.Views.Home;
using Xamarin.Forms.Xaml;
using System.Linq;
using SQLitePCL;
using Xamarin.Essentials;
using Bewize.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Bewize.HelperResource;
using System.IO;
using Bewize.Views;

namespace Bewize
{
    public partial class App : Application
    {
        // public static object HttpClientHandler;
        public static string DatabaseLocation = string.Empty;
        public static string Token = "";

        static SQLiteHelper db;
        public App ()
        {
            InitializeComponent();
            //var tokencount = Application.Current.Properties.ToList();
            //if (tokencount > 0)
            //{
            //    MainPage = new NavigationPage(new WelcomePage_());
            //}
            //else {
            //    MainPage = new NavigationPage(new MainPage_());
            //}
        }

        public App(string dbLocation)
        {
            InitializeComponent();

            DatabaseLocation = dbLocation;

            bool hasKey = Preferences.ContainsKey("Token");
            if (hasKey)
            {
                var token = Preferences.Get("Token", "");
                if (token != null && token != "")
                { MainPage = new NavigationPage(new WelcomePage_()); } else
                { MainPage = new NavigationPage(new MainPage_());  }
            }
            else
            {
                MainPage = new NavigationPage(new MainPage_());
            }
        }

        protected override async void OnStart ()
        {
           /* var appleSignInService = DependencyService.Get<IAppleSignInService>();
            if (appleSignInService != null)
            {
               userId = await SecureStorage.GetAsync(AppleUserIdKey);
                if (appleSignInService.IsAvailable && !string.IsNullOrEmpty(userId))
                {

                    var credentialState = await appleSignInService.GetCredentialStateAsync(userId);

                    switch (credentialState)
                    {
                        case AppleSignInCredentialState.Authorized:
                            //Normal app workflow...
                            break;
                        case AppleSignInCredentialState.NotFound:
                        case AppleSignInCredentialState.Revoked:
                            //Logout;
                            SecureStorage.Remove(AppleUserIdKey);
                            Preferences.Set(LoggedInKey, false);
                            MainPage = new LoginPage();
                            break;
                    }
                }
            }*/

        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }

        public static SQLiteHelper SQLiteDb
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinSQLite.db3"));
                }
                return db;
            }
        }
    }
}

