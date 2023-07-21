using System;
using Bewize.HelperResource;
using Bewize.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Bewize.Views.Home;
using System.Linq;
using Xamarin.Forms.GoogleMaps;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Bewize.ViewModels
{
	public class MyratingsListVM : BaseViewModel
	{
        CancellationTokenSource cts;
        public ClosebtnCommand Closebtn_Command { get; set; }

        private List<MyRatingsDetails> _MyRatingsDetailslist { get; set; }
        public List<MyRatingsDetails> MyRatingsDetailsList
        {
            get { return _MyRatingsDetailslist; }
            set
            {
                _MyRatingsDetailslist = value;
                OnPropertyChanged();
            }
        }

        private List<Submittedrating> _MyRatingsDetails { get; set; }
        public List<Submittedrating> MyRatingsDetails
        {
            get { return _MyRatingsDetails; }
            set
            {
                _MyRatingsDetails = value;
                OnPropertyChanged();
            }
        }


        public MyratingsListVM()
        {
            Closebtn_Command = new ClosebtnCommand(this);
           
            //this.GetMyRatingsDetailsFromServer();
        }

        public async Task<string> getLocationtitleAsync(string lat, string lon) {

            Geocoder geoCoder = new Geocoder();
            Position position = new Position(Convert.ToDouble(lat), Convert.ToDouble(lon));
            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
            string address = possibleAddresses.FirstOrDefault();
            return address;
        }

        public class ClosebtnCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private MyratingsListVM VM;

            public ClosebtnCommand(MyratingsListVM vm)
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
        public void MoveBackwardScreen()
        {
           
                App.Current.MainPage.Navigation.PushAsync(new Views.Home.MyHomepage());
           
        }

        public void MoveForwardtoViewdetails()
        {

            App.Current.MainPage.Navigation.PushAsync(new Views.MyRating.MyRatingsProPg(true));

        }


        public async void GetMyRatingsDetailsFromServer()
        {
            try
            {
                string webURL = APIHelper.myrating;
                HttpHelper httpHelper = new HttpHelper();
                APIResponse res = await httpHelper.callAPI(webURL, "");

                if (res.success)
                {
                    this.MyRatingsDetailsList = new List<MyRatingsDetails>();
                    this.MyRatingsDetails = new List<Submittedrating>();
                    string obj = JsonConvert.SerializeObject(res.data);
                    var list = JsonConvert.DeserializeObject<List<MyRatingsDetails>>(obj);
                    foreach (MyRatingsDetails submittedrating in list) {
                        if (submittedrating.name == "" || submittedrating.name == null)
                        {
                            submittedrating.name = "Data not available!";
                        }
                        if (submittedrating.my_ratings != null)
                        {
                            SubmittedratingList mylist = new SubmittedratingList();
                            mylist.my_ratings = submittedrating.my_ratings;
                            this.MyRatingsDetails = mylist.my_ratings;
                        }
                    }
                    this.MyRatingsDetailsList = list;
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
    }
}

