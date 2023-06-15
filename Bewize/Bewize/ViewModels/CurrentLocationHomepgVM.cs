using System;
using System.Windows.Input;
using Bewize.HelperResource;
using Bewize.Models;
using Bewize.Views;
using Bewize.Views.Home;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;

namespace Bewize.ViewModels
{
    public class CurrentLocationHomepgVM : BaseViewModel
    {
        public GetCurrentlocationdetailsCommand getLocationdetails_cmd { get; set; }

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

        public CurrentLocationHomepgVM()
        {
            getLocationdetails_cmd = new GetCurrentlocationdetailsCommand(this);


        }


        public async void getlocationdetailswithScore()
        {

            var Longitude = Preferences.Get("Longitude", "");
            var Latitude = Preferences.Get("Latitude", "");

            if (Longitude != "" && Latitude != "")
            {
                try
                {
                    string webURL = APIHelper.Currentlocationdetails;
                    HttpHelper httpHelper = new HttpHelper();

                    var locationinfo = new Locationinfo_reqPara();
                    locationinfo.longitude = Longitude;
                    locationinfo.latitude = Latitude;

                    APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(locationinfo));

                    if (res.success)
                    {
                       
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

        public async void PopLocationdetails()
        {
            // App.Current.MainPage.Navigation.Pus
            await PopupNavigation.Instance.PushAsync(new Views.Home.LocationDetails());
        }

    }

        public class GetCurrentlocationdetailsCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private CurrentLocationHomepgVM VM;

            public GetCurrentlocationdetailsCommand(CurrentLocationHomepgVM vm)
            {
                VM = vm;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                 VM.PopLocationdetails();
            }

        }


    
}

