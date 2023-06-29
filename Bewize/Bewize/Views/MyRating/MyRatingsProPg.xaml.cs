using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Core;
using Bewize.ViewModels;
using Bewize.Models;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;
using System.Linq;
using Xamarin.Forms.GoogleMaps;
using Bewize.HelperResource;

namespace Bewize.Views.MyRating
{
    public partial class MyRatingsProPg : ContentPage
    {
        MyRatingsProVM VM;
        Xamarin.Forms.GoogleMaps.Map map;
        Geocoder geoCoder = new Geocoder();
        bool isFromratingList = false;

        public MyRatingsProPg(bool isFromRatingList)
        {
            InitializeComponent();
            VM = new MyRatingsProVM();
            BindingContext = VM;

            VM.getQuestionslistfromserver();
            this.isFromratingList = isFromRatingList;

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.SubmitAnswer_list = new SubmitAnsList_reqPara();
            VM.SubmitAnswer_list.ansList = new List<SubmitAns_reqPara>();
            this.ReloadLocationMap();

        }

        async void ReloadLocationMap()
        {
            var Longitude = Preferences.Get("Longitude", "");
            var Latitude = Preferences.Get("Latitude", "");
            if (Longitude != null && Latitude != null)
            {
                try
                {
                    //Position currentposition = new Position(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude));
                    //IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(currentposition);
                    //string address = possibleAddresses.FirstOrDefault();
                    Placeaddresslbl.Text = await UtilityHelper.GetAddressFromLatLong(Latitude, Longitude);

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
                    Xamarin.Forms.GoogleMaps.MapSpan mapSpan = new Xamarin.Forms.GoogleMaps.MapSpan(position, 0.01, 0.01);
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
                }
                catch (Exception ex)
                {
                    ContentMap.IsVisible = false;

                }
            }
        }
        public static string selectedColor = "#90FFE8EC";
        public static string unSelectedColor = "#00ffffff";

        void Ratebtn1_Clicked(System.Object sender, System.EventArgs e)
        {
            ImageButton button = (ImageButton)sender;

            var bindItem = (RatingSelected)button.BindingContext;

            var copyList = new List<Questionsdetails>(VM.RateQuestionslist);
            var mainItemIndex = copyList.FindIndex(v => v._id == bindItem._id);
            var item = VM.RateQuestionslist[mainItemIndex];// current main item selected

            var subIndex = copyList[mainItemIndex].ratings.ToList().FindIndex(v => v.currentSelectedAns == bindItem.currentSelectedAns);

            for (int i = 0; i < copyList[mainItemIndex].ratings.Count; i++)
            {
                if (i == subIndex)
                {
                    copyList[mainItemIndex].ratings[i].BGColor = selectedColor;
                }
                else
                {
                    copyList[mainItemIndex].ratings[i].BGColor = unSelectedColor;
                }
            }

            VM.RateQuestionslist[mainItemIndex] = copyList[mainItemIndex];

            var Longitude = Preferences.Get("Longitude", "");
            var Latitude = Preferences.Get("Latitude", "");
            var reqPara = new SubmitAns_reqPara();
            reqPara.ans = bindItem.currentSelectedAns;
            reqPara.que = item._id;
            reqPara.longitude = Longitude;
            reqPara.latitude = Latitude;
            reqPara.crime_type = item.crime_type;
            reqPara.createdby = "";
            reqPara.updatedby = "";

            if (VM.SubmitAnswer_list.ansList.Count > 0)
            {
                if (!VM.SubmitAnswer_list.ansList.Any(x => x.que == reqPara.que))
                {
                    VM.SubmitAnswer_list.ansList.Add(reqPara);
                }

                if (VM.SubmitAnswer_list.ansList.Any(x => x.que == reqPara.que))
                {
                    //do something here to check if both rows are same, if not update the row with new values

                    VM.SubmitAnswer_list.ansList.Where(c => c.que == reqPara.que)
                        .ToList()
                        .ForEach(c => c.ans = reqPara.ans);
                }
            }
            else
                VM.SubmitAnswer_list.ansList.Add(reqPara);
        }

        //void Ratebtntwo_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    ImageButton button = (ImageButton)sender;
        //    if (button.BackgroundColor == Color.FromHex("#00ffffff"))
        //    {
        //        button.BackgroundColor = Color.FromHex("#90FFECDF");
        //        button.BorderColor = Color.FromHex("#80FFECDF");
        //        button.BorderWidth = 0.2;

        //        var item = (Questionsdetails)button.BindingContext;
        //        var Longitude = Preferences.Get("Longitude", "");
        //        var Latitude = Preferences.Get("Latitude", "");

        //        var reqPara = new SubmitAns_reqPara();
        //        reqPara.ans = "2";
        //        reqPara.que = item._id;
        //        reqPara.longitude = Longitude;
        //        reqPara.latitude = Latitude;
        //        reqPara.crime_type = item.crime_type;
        //        reqPara.createdby = "";
        //        reqPara.updatedby = "";

        //        this.SubmitAnswer_list.ansList.Add(reqPara);

        //        var obj = VM.RateQuestionslist.FirstOrDefault(v => v._id == item._id);

        //    }
        //    else
        //    {
        //        this.SubmitAnswer_list.ansList = (List<SubmitAns_reqPara>)this.SubmitAnswer_list.ansList.Where(x => x.ans != "2");

        //        button.BackgroundColor = Color.FromHex("#00ffffff");
        //        button.BorderWidth = 0;
        //    }



        //}

        //void RatebtnThird_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    ImageButton button = (ImageButton)sender;
        //    if (button.BackgroundColor == Color.FromHex("#00ffffff"))
        //    {
        //        button.BackgroundColor = Color.FromHex("#90FFF8CF");
        //        button.BorderColor = Color.FromHex("#80FFF8CF");
        //        button.BorderWidth = 0.2;

        //        var item = (Questionsdetails)button.BindingContext;
        //        var Longitude = Preferences.Get("Longitude", "");
        //        var Latitude = Preferences.Get("Latitude", "");

        //        var reqPara = new SubmitAns_reqPara();
        //        reqPara.ans = "3";
        //        reqPara.que = item._id;
        //        reqPara.longitude = Longitude;
        //        reqPara.latitude = Latitude;
        //        reqPara.crime_type = item.crime_type;
        //        reqPara.createdby = "";
        //        reqPara.updatedby = "";

        //        this.SubmitAnswer_list.ansList.Add(reqPara);

        //        var obj = VM.RateQuestionslist.FirstOrDefault(v => v._id == item._id);

        //    }
        //    else
        //    {
        //        this.SubmitAnswer_list.ansList = (List<SubmitAns_reqPara>)this.SubmitAnswer_list.ansList.Where(x => x.ans != "3");

        //        button.BackgroundColor = Color.FromHex("#00ffffff");
        //        button.BorderWidth = 0;
        //    }


        //}

        //void RatebtnFour_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    ImageButton button = (ImageButton)sender;
        //    var row = Grid.GetRow(button);
        //    var grid = button.Parent as Grid;
        //    var cell = grid.Parent as ViewCell;

        //    if (button.BackgroundColor == Color.FromHex("#00ffffff"))
        //    {
        //        button.BackgroundColor = Color.FromHex("#90E9FFCA");
        //        button.BorderColor = Color.FromHex("#80E9FFCA");
        //        button.BorderWidth = 0.2;

        //        var item = (Questionsdetails)button.BindingContext;
        //        var Longitude = Preferences.Get("Longitude", "");
        //        var Latitude = Preferences.Get("Latitude", "");
        //        var reqPara = new SubmitAns_reqPara();
        //        reqPara.ans = "4";
        //        reqPara.que = item._id;
        //        reqPara.longitude = Longitude;
        //        reqPara.latitude = Latitude;
        //        reqPara.crime_type = item.crime_type;
        //        reqPara.createdby = "";
        //        reqPara.updatedby = "";

        //        this.SubmitAnswer_list.ansList.Add(reqPara);

        //        var obj = VM.RateQuestionslist.FirstOrDefault(v => v._id == item._id);
        //    }
        //    else
        //    {
        //        this.SubmitAnswer_list.ansList = (List<SubmitAns_reqPara>)this.SubmitAnswer_list.ansList.Where(x => x.ans != "4");
        //        button.BackgroundColor = Color.FromHex("#00ffffff");
        //        button.BorderWidth = 0;
        //    }


        //}

        //void RatebtnFive_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    ImageButton button = (ImageButton)sender;
        //    if (button.BackgroundColor == Color.FromHex("#00ffffff"))
        //    {
        //        button.BackgroundColor = Color.FromHex("#90C7FFE1");
        //        button.BorderColor = Color.FromHex("#80C7FFE1");
        //        button.BorderWidth = 0.2;

        //        var item = (Questionsdetails)button.BindingContext;
        //        var Longitude = Preferences.Get("Longitude", "");
        //        var Latitude = Preferences.Get("Latitude", "");
        //        var reqPara = new SubmitAns_reqPara();
        //        reqPara.ans = "5";
        //        reqPara.que = item._id;
        //        reqPara.longitude = Longitude;
        //        reqPara.latitude = Latitude;
        //        if (item.crime_type != null)
        //        {
        //            reqPara.crime_type = item.crime_type;
        //        }
        //        else
        //        {
        //            reqPara.crime_type = "";
        //        }
        //        reqPara.createdby = "";
        //        reqPara.updatedby = "";

        //        this.SubmitAnswer_list.ansList.Add(reqPara);

        //        var obj = VM.RateQuestionslist.FirstOrDefault(v => v._id == item._id);
        //    }
        //    else
        //    {
        //        this.SubmitAnswer_list.ansList = (List<SubmitAns_reqPara>)this.SubmitAnswer_list.ansList.Where(x => x.ans != "5");

        //        button.BackgroundColor = Color.FromHex("#00ffffff");
        //        button.BorderWidth = 0;
        //    }

        //}

        public void YescheckBox_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (this.YescheckBox.IsChecked)
            {
                VM.SelectCrimetypefromPopup();
                this.NocheckBox.IsChecked = false;
            }
        }


        public void NocheckBox_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (NocheckBox.IsChecked)
            {
                this.YescheckBox.IsChecked = false;
            }
        }

        public async void Submit_allanswers_Clicked(System.Object sender, System.EventArgs e)
        {
            if (VM.SubmitAnswer_list.ansList.Count > 0)
            {
                VM.SubmitAnswertoServer(VM.SubmitAnswer_list);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("", "Please add appropriate answers.", "OK");

            }
        }
    }
}

