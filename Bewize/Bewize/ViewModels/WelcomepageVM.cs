using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Bewize.HelperResource;
using Bewize.Models;
using Bewize.Views;
using Bewize.Views.Home;
using Bewize.Views.Profile;
using Newtonsoft.Json;
using Plugin.Permissions;
using Xamarin.Essentials;
using Xamarin.Forms;
//using Xamarin.Forms.Maps;



namespace Bewize.ViewModels
{
    public class WelcomepageVM
    {
        public UsercurrentlocationbtnCommand Currentlocationbtncmd { get; set; }
        public ConitnuewithZipcodeCommand zipcodecontinuebtncmd { get; set; }
        public welcomescreenbackbtnCommand welcomebackbtn_cmd { get; set; }
        CancellationTokenSource cts;
        MapHelper Location_Data = new MapHelper();
     //   Geocoder geoCoder = new Geocoder();

        public WelcomepageVM()
        {

            Currentlocationbtncmd = new UsercurrentlocationbtnCommand(this);
            zipcodecontinuebtncmd = new ConitnuewithZipcodeCommand(this);
            welcomebackbtn_cmd = new welcomescreenbackbtnCommand(this);
          
        }


        public async void MoveForwardwithZipcode(string Zipcode)
        {
            await GetMyLocationdetails(Zipcode);
        }

        public void Continuewith_UserCurrentLocationAccess()
        {
            App.Current.MainPage.Navigation.PushAsync(new MyLocationHomepage());
        }


        async Task GetMyLocationdetails(string Zipcode)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(Zipcode);

                var location = locations?.FirstOrDefault();
                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Preferences.Set("Latitude", location.Latitude.ToString());
                    Preferences.Set("Longitude", location.Longitude.ToString());
                    App.Current.MainPage.Navigation.PushAsync(new MyLocationHomepage());
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert(fnsEx.ToString(), "Location details required for better experience.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.ToString(), "Location details required for better experience.", "OK");
            }
        }

        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
            {
                // Prompt the user with additional information as to why the permission is needed
            }

            status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            return status;
        }

        public async void checkLocationAccess() {
            try
            {
                var status = await CheckAndRequestLocationPermission();
                if (status == PermissionStatus.Granted)
                {
                    //Device.StartTimer(TimeSpan.FromSeconds(120), () =>
                    //{
                        GetCurrentLocation();
                     //   return true;
                   // });

                }
                else
                {
                    await DisplayAlert("Enable location", "Location details required for better experience.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert(ex.ToString(), "Location details required for better experience.", "OK");
            }
        }
        async Task GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);
                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Preferences.Set("Latitude",location.Latitude.ToString());
                    Preferences.Set("Longitude", location.Longitude.ToString());
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
        private Task DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }

    public class UsercurrentlocationbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private WelcomepageVM VM;

        public UsercurrentlocationbtnCommand(WelcomepageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Continuewith_UserCurrentLocationAccess();
        }

    }

    public class ConitnuewithZipcodeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private WelcomepageVM VM;

        public ConitnuewithZipcodeCommand(WelcomepageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           // VM.MoveForwardwithZipcode();
        }

    }


    public class welcomescreenbackbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private WelcomepageVM VM;

        public welcomescreenbackbtnCommand(WelcomepageVM vm)
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