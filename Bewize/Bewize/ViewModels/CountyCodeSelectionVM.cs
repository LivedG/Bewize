using System;
using System.Collections.Generic;
using Bewize.Models;
using Bewize.HelperResource;
using Newtonsoft.Json;

namespace Bewize.ViewModels
{
	public class CountyCodeSelectionVM : BaseViewModel
	{

        private Country _SelectedCountry { get; set; }
        public Country SelectedCountry
        {
            get { return _SelectedCountry; }
            set
            {
                _SelectedCountry = value;
                OnPropertyChanged();
            }
        }

        private List<Country> _Countrylist { get; set; }
        public List<Country> CountryList
        {
            get { return _Countrylist; }
            set
            {
                _Countrylist = value;
                OnPropertyChanged();
            }
        }

        public CountyCodeSelectionVM()
		{
            SelectedCountry = new Country();
        }


        public async void GetCountryListFromServer()
        {
            try
            {
                 string webURL = APIHelper.Allcountrywithflag;
                 HttpHelper httpHelper = new HttpHelper();
                APIResponse res = await httpHelper.callAPI(webURL, "");

                if (res.success)
                {
                    this.CountryList = new List<Country>();
                    string obj = JsonConvert.SerializeObject(res.data);
                    this.CountryList = JsonConvert.DeserializeObject<List<Country>>(obj);
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

