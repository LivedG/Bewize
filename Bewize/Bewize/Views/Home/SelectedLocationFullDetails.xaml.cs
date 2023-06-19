using System;
using System.Collections.Generic;
using System.Linq;
using Bewize.HelperResource;
using Bewize.Models;
using Bewize.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Bewize.Views.Home
{
    public partial class SelectedLocationFullDetails : ContentPage
    {
        SelectedLocationfullDetailsVM vm;
        Xamarin.Forms.GoogleMaps.Map map;
        Geocoder geoCoder = new Geocoder();

        public SelectedLocationFullDetails(LocationScoreDetails locationdata)
        {
            InitializeComponent();
            vm = new SelectedLocationfullDetailsVM();
            BindingContext = vm;
            vm.selectedPinlocationdetails = locationdata;
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.getlocationcrimeDetails();
            this.SetupLocationdetails(vm.selectedPinlocationdetails);
            this.VisibleGeocrimeview();

        }

        public void VisibleGeocrimeview()
        {
            geoCrimebtn.BackgroundColor = Color.White;
            geoCrimebtn.TextColor = Color.CornflowerBlue;
            gunViolencebtn.BackgroundColor = Color.Transparent;
            gunViolencebtn.TextColor = Color.Gray;
            this.GeoCrimeContent.IsVisible = true;
            this.GunviolenceContent.IsVisible = false;

        }


        public void VisibleGunviolenceview()
        {
            geoCrimebtn.BackgroundColor = Color.Transparent;
            geoCrimebtn.TextColor = Color.DarkGray;
            gunViolencebtn.BackgroundColor = Color.White;
            gunViolencebtn.TextColor = Color.CornflowerBlue;
            this.GeoCrimeContent.IsVisible = false;
            this.GunviolenceContent.IsVisible = true;
        }

        [Obsolete]
        async void SetupLocationdetails(LocationScoreDetails details)
        {
            var Longitude = Preferences.Get("Longitude", "");
            var Latitude = Preferences.Get("Latitude", "");

            if (details.LONGITUDE != null && details.LATITUDE != null)
             {
                try
                {
                    //Position currentposition = new Position(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude));
                    //IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(currentposition);
                    //string address = await UtilityHelper.GetAddressFromLatLong(Latitude, Longitude);

                    address_lbl.Text = details.NAME;
                    map = new Xamarin.Forms.GoogleMaps.Map()
                    {
                        Margin = new Thickness(0.1, 0.2, 0.2, 0.2),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        MapType = Xamarin.Forms.GoogleMaps.MapType.Street,
                        HasZoomEnabled = false,
                        HasScrollEnabled = false,
                        IsEnabled = true
                    };
                    Xamarin.Forms.GoogleMaps.Position position = new Xamarin.Forms.GoogleMaps.Position(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude));
                    Xamarin.Forms.GoogleMaps.MapSpan mapSpan = new Xamarin.Forms.GoogleMaps.MapSpan(position, 0.5, 0.5);
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

                    //Pin pin = new Pin
                    //{
                    //    Type = PinType.Place,
                    //    Position = position
                    //};
                    //map.Pins.Add(pin);
                }
                catch (Exception ex)
                {
                    ContentMap.IsVisible = false;

                }
            }
        }

        async void gunViolencebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("", "Available soon.", "OK");
            //await App.Current.MainPage.Navigation.PopAsync();
           // this.VisibleGunviolenceview();
        }
        void geoCrimebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            this.VisibleGeocrimeview();
        }
    }
}

