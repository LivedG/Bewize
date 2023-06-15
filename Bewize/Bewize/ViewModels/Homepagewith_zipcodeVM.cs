using System;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using Bewize.Models;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using Bewize.HelperResource;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrackingSample.Helpers;

namespace Bewize.ViewModels
{
	public class Homepagewith_zipcodeVM:BaseViewModel
	{
        public  GetSelectedlocationdetailsCommand getselected_locationdetailscmd { get; set; }
        public RateLocationCommand setLocationratingcmd { get; set; }
        IGoogleMapsApiServices googleMapsApi = new GoogleMapsApiService();

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

        public bool _isLoaderVisible { get; set; }
        public bool isLoaderVisible
        {
            get { return _isLoaderVisible; }
            set
            {
                _isLoaderVisible = value;
                OnPropertyChanged();
            }
        }

        public List<LocationScoreDetails>  _Locationscoredetails { get; set; }
        public List<LocationScoreDetails>   Locationscoredetails
        {
            get { return _Locationscoredetails; }
            set
            {
                _Locationscoredetails = value;
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

        bool _hasRouteRunning;
        string _originLatitud;
        string _originLongitud;
        string _destinationLatitud;
        string _destinationLongitud;
        public ICommand CalculateRouteCommand { get; set; }
        public ICommand UpdatePositionCommand { get; set; }

        public ICommand LoadRouteCommand { get; set; }
        public ICommand StopRouteCommand { get; set; }
        GooglePlaceAutoCompletePrediction _placeSelected;
        public GooglePlaceAutoCompletePrediction PlaceSelected
        {
            get
            {
                return _placeSelected;
            }
            set
            {
                _placeSelected = value;
                if (_placeSelected != null)
                    GetPlaceDetailCommand.Execute(_placeSelected);
            }
        }
        public ICommand FocusOriginCommand { get; set; }
        public ICommand GetPlacesCommand { get; set; }
        public ICommand GetPlaceDetailCommand { get; set; }

        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places { get; set; }
        public ObservableCollection<GooglePlaceAutoCompletePrediction> RecentPlaces { get; set; } = new ObservableCollection<GooglePlaceAutoCompletePrediction>();

        public bool ShowRecentPlaces { get; set; }
        bool _isPickupFocused = true;

        string _pickupText;
        public string PickupText
        {
            get
            {
                return _pickupText;
            }
            set
            {
                _pickupText = value;
                if (!string.IsNullOrEmpty(_pickupText))
                {
                    _isPickupFocused = true;
                    GetPlacesCommand.Execute(_pickupText);
                }
            }
        }

        string _originText;
        public string OriginText
        {
            get
            {
                return _originText;
            }
            set
            {
                _originText = value;
                if (!string.IsNullOrEmpty(_originText))
                {
                    _isPickupFocused = false;
                    GetPlacesCommand.Execute(_originText);
                }
            }
        }


        public Homepagewith_zipcodeVM()
		{
            getselected_locationdetailscmd = new GetSelectedlocationdetailsCommand(this);
            setLocationratingcmd = new RateLocationCommand(this);
            GetPlacesCommand = new Command<string>(async (param) => await GetPlacesByName(param));
            GetPlaceDetailCommand = new Command<GooglePlaceAutoCompletePrediction>(async (param) => await GetPlacesDetail(param));
            LoadRouteCommand = new Command(async () => await LoadRoute());
            StopRouteCommand = new Command(StopRoute);
            this.GetProfiledatafromlocalStorage();
        }
        public void StopRoute()
        {
            _hasRouteRunning = false;
        }

        public async Task<List<LocationScoreDetails>> getlocationdetailswithScore()
        {
            var Longitude = Preferences.Get("Longitude", "");
            var Latitude =  Preferences.Get("Latitude", "");
           
            if (Longitude != "" && Latitude != "")
            {
                try
                {
                    string webURL = APIHelper.Getlocationswithinradius;
                    HttpHelper httpHelper = new HttpHelper();

                    var locationinfo = new Locationinfo_reqPara();
                    locationinfo.longitude = Longitude;
                    locationinfo.latitude = Latitude;

                    APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(locationinfo));
                    if (res.success)
                    {
                        List<LocationScoreDetails> details = new List<LocationScoreDetails>();
                        var obj = JsonConvert.SerializeObject(res.data);
                        details = JsonConvert.DeserializeObject<List<LocationScoreDetails>>(obj);
                        if (details.Count > 0)
                        {
                            this.Locationscoredetails = details;
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("", "Location score details not available,you may rate it now!", "OK");
                        }
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
            else {
                await App.Current.MainPage.DisplayAlert("", "Location score details not available,you may rate it now!", "OK");
            }
            return this.Locationscoredetails;
        }

        public async void showLocationdetails(LocationScoreDetails details) {
            await App.Current.MainPage.Navigation.PushAsync(new Views.Home.SelectedLocationFullDetails(details));
        }

        public async void GetProfiledatafromlocalStorage()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var userList = await App.SQLiteDb.GetItemsAsync();

                if (userList.Count > 0)
                {
                    this.Profiledetails = userList.Last();
                 
                }
                else {
                    await App.Current.MainPage.DisplayAlert("", "Please fill your acccount details for better experience.", "OK");
                }
            }

        }



        public void setLocationRatingDetails()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.MyRating.MyRatingsProPg(false));
        }


        public async void PopLocationdetails()
        {
            await PopupNavigation.Instance.PushAsync(new Views.Home.SelectedLocationDetails());
        }

        public async Task GetPlacesByName(string placeText)
        {
            var places = await googleMapsApi.GetPlaces(placeText);
            var placeResult = places.AutoCompletePlaces;
            if (placeResult != null && placeResult.Count > 0)
            {
                Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);
            }

            ShowRecentPlaces = (placeResult == null || placeResult.Count == 0);
        }

        public async Task GetPlacesDetail(GooglePlaceAutoCompletePrediction placeA)
        {
            var place = await googleMapsApi.GetPlaceDetails(placeA.PlaceId);
            if (place != null)
            {
                if (_isPickupFocused)
                {
                    PickupText = place.Name;
                    _originLatitud = $"{place.Latitude}";
                    _originLongitud = $"{place.Longitude}";
                    _isPickupFocused = false;
                    FocusOriginCommand.Execute(null);
                }
                else
                {
                    _destinationLatitud = $"{place.Latitude}";
                    _destinationLongitud = $"{place.Longitude}";

                    RecentPlaces.Add(placeA);

                    if (_originLatitud == _destinationLatitud && _originLongitud == _destinationLongitud)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Origin route should be different than destination route", "Ok");
                    }
                    else
                    {
                        LoadRouteCommand.Execute(null);
                        await App.Current.MainPage.Navigation.PopAsync(false);
                        CleanFields();
                    }

                }
            }
        }

        public async Task LoadRoute()
        {
            var positionIndex = 1;
            var googleDirection = await googleMapsApi.GetDirections(_originLatitud, _originLongitud, _destinationLatitud, _destinationLongitud);
            if (googleDirection.Routes != null && googleDirection.Routes.Count > 0)
            {
                var positions = (Enumerable.ToList(PolylineHelper.Decode(googleDirection.Routes.First().OverviewPolyline.Points)));
                CalculateRouteCommand.Execute(positions);

                _hasRouteRunning = true;

                //Location tracking simulation
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (positions.Count > positionIndex && _hasRouteRunning)
                    {
                        UpdatePositionCommand.Execute(positions[positionIndex]);
                        positionIndex++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(":(", "No route found", "Ok");
            }

        }

        void CleanFields()
        {
            PickupText = OriginText = string.Empty;
            ShowRecentPlaces = true;
            PlaceSelected = null;
        }
    }

    public class GetSelectedlocationdetailsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Homepagewith_zipcodeVM VM;

        public GetSelectedlocationdetailsCommand(Homepagewith_zipcodeVM vm)
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

    public class RateLocationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Homepagewith_zipcodeVM VM;

        public RateLocationCommand(Homepagewith_zipcodeVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.setLocationRatingDetails();
        }

    }


}

