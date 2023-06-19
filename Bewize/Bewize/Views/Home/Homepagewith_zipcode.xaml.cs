using System;
using System.Collections.Generic;
using Bewize.HelperResource;
using Bewize.ViewModels;
using Bewize.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;
using Xamarin.Forms.Maps;
using Xamarin.Forms.GoogleMaps;
using Geocoder = Xamarin.Forms.GoogleMaps.Geocoder;
using Position = Xamarin.Forms.GoogleMaps.Position;
using Lottie.Forms;

namespace Bewize.Views.Home
{
    public partial class Homepagewith_zipcode : ContentPage
    {
        Homepagewith_zipcodeVM vm;
        List<LocationScoreDetails> location_details;
        Xamarin.Forms.GoogleMaps.Map map;
        Geocoder geoCoder = new Geocoder();

        public Homepagewith_zipcode()
        {
            InitializeComponent();
            vm = new Homepagewith_zipcodeVM();
            BindingContext = vm;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //vm.isLoaderVisible = true;
            this.location_details = new List<LocationScoreDetails>();
            if (vm.Profiledetails.profile_img != null && vm.Profiledetails.profile_img != "")
            {
                this.setupProfilepicture(vm.Profiledetails.profile_img);
            }
            ReloadLocationMap();
            this.checklocationScoreavailableorNot();

        }

        void checklocationScoreavailableorNot()
        {
            //if (this.location_details.NAME != null && this.location_details.NAME != "")   {
            //    RatingDisplayview.IsVisible = true;
            //}
            //else {
            RatingDisplayview.IsVisible = false;
            // }
        }
        async void ReloadLocationMap()
        {
            //"LATITUDE": "32.4643",
            //"LONGITUDE": "-86.4863",


            var Longitude = "-86.4863"; // Preferences.Get("Longitude", "");
            var Latitude = "32.4643";// Preferences.Get("Latitude", "");
            if (Longitude != null && Latitude != null)
            {
                try
                {
                    //Position currentposition = new Position(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude));
                    //IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(currentposition);
                    string address = await UtilityHelper.GetAddressFromLatLong(Latitude, Longitude);
                    locationlbl.Text = address;
                    map = new Xamarin.Forms.GoogleMaps.Map()
                    {
                        Margin = new Thickness(2, 2, 2, 2),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        MapType = Xamarin.Forms.GoogleMaps.MapType.Street,
                        HasZoomEnabled = true,
                        HasScrollEnabled = true,
                        IsEnabled = true
                    };
                    Xamarin.Forms.GoogleMaps.Position position = new Xamarin.Forms.GoogleMaps.Position(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude));
                    Xamarin.Forms.GoogleMaps.MapSpan mapSpan = new Xamarin.Forms.GoogleMaps.MapSpan(position, 0.05, 0.05);
                    map.MoveToRegion(mapSpan);
                    StackLayout stackLayout = new StackLayout()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        BackgroundColor = Color.Transparent,
                        Orientation = StackOrientation.Vertical
                    };
                    stackLayout.Children.Add(map);
                    ContentMap.Content = stackLayout;
                    ContentMap.IsVisible = true;
                    this.location_details = await vm.getlocationdetailswithScore();
                    this.setupPinLocation();
                }
                catch (Exception ex)
                {
                    ContentMap.IsVisible = false;

                }
            }
        }
        async void setupProfilepicture(string picurl)
        {
            try
            {
                var imagebytes = ImageService.DownlodaImage(picurl);
                ImageService.SavetoDisk("Profilepic", imagebytes);
                profileimage.Source = ImageService.GetFromDisk("Profilepic");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");
            }
        }


        void setupPinLocation()
        {
            if (this.location_details.Count > 0)
            {

                foreach (LocationScoreDetails location in this.location_details)
                {
                    Xamarin.Forms.GoogleMaps.Pin positionpin = new Xamarin.Forms.GoogleMaps.Pin()
                    {
                        Label = location.NAME,
                        Position = new Xamarin.Forms.GoogleMaps.Position(Convert.ToDouble(location.LATITUDE), Convert.ToDouble(location.LONGITUDE)),
                        Icon = BitmapDescriptorFactory.FromBundle(location.CRMCYTOTC),
                        Type = Xamarin.Forms.GoogleMaps.PinType.Place,


                    };
                    positionpin.Clicked += (sender, args) =>
                    {
                        var locaiondata = this.location_details.ToList().Where(x => x.LATITUDE == positionpin.Position.Latitude.ToString() &&
                         x.LONGITUDE == positionpin.Position.Longitude.ToString()).First();
                        if (locaiondata != null) { vm.showLocationdetails(locaiondata); }
                    };
                    map.Pins.Add(positionpin);
                }
            }
            // vm.isLoaderVisible = false;
        }
    }
}

