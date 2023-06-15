using System;

using System.Collections.Generic;
using Bewize.HelperResource;
using Bewize.Models;
using Newtonsoft.Json;

using Bewize.Models;



namespace Bewize.ViewModels
{
	public class CrimeTypePopupVM : BaseViewModel
	{

        public double _OverWindowheight { get; set; }
        public double OverWindowheight
        {
            get { return _OverWindowheight; }
            set
            {
                _OverWindowheight = value;

                OnPropertyChanged();
            }
        }

        public double _listviewheight { get; set; }
        public double listviewheight
        {
            get { return _OverWindowheight; }
            set
            {
                _listviewheight = value;
                OnPropertyChanged();
            }
        }

        public bool _isListviewvisible { get; set; }
        public bool isListviewvisible
        {
            get { return _isListviewvisible; }
            set
            {
                _isListviewvisible = value;
                OnPropertyChanged();
            }
        }

        public CrimeType _selectedCrimetype { get; set; }
        public CrimeType SelectedCrimetype
        {
            get { return _selectedCrimetype; }
            set
            {
                _selectedCrimetype = value;
                OnPropertyChanged();
            }
        }

        public List<CrimeType> _Crimetypelist { get; set; }
        public List<CrimeType> Crimetypelist
        {
            get { return _Crimetypelist; }
            set
            {
                _Crimetypelist = value;
                OnPropertyChanged();
            }
        }



        public CrimeTypePopupVM()
		{
		}

        public void Crimetypelistvisible(bool isvisible)
        {
            this.isListviewvisible = isvisible;
            if (this.isListviewvisible == true)
            {

                this.OverWindowheight = 480;
                this.listviewheight = 250;
            }
            else {
                this.OverWindowheight = 250;
                this.listviewheight = 0;
            }
        }

        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        public async void getCrimetypelistfromserver()
        {

            try
            {

                string webURL = APIHelper.Crimetypelist;
                HttpHelper httpHelper = new HttpHelper();

                APIResponse res = await httpHelper.callAPI(webURL,"");

                if (res.success)
                {
                    List<CrimeType> details = new List<CrimeType>();
                    var obj = JsonConvert.SerializeObject(res.data);
                    details = JsonConvert.DeserializeObject<List<CrimeType>>(obj);
                    if (details.Count > 0)
                    {
                        this.Crimetypelist = details;
                    }
                    else {
                        await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                    }
                   // App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                   // message = res.message;
                    // isActivity = false;
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
            }
            catch (Exception ex)
            {
                // isActivity = false;
                //message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");

            }


        }
    }
}

