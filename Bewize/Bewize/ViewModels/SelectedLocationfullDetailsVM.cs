using System;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Bewize.Models;
using Bewize.Views.Home;
using Bewize.HelperResource;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bewize.ViewModels
{
	public class SelectedLocationfullDetailsVM : BaseViewModel
	{
        public BackbtnActionCommand backbtnAction { get; set; }

        public LocationScoreDetails _selectedPinlocationdetails { get; set; }
        public LocationScoreDetails selectedPinlocationdetails
        {
            get { return _selectedPinlocationdetails; }
            set
            {
                _selectedPinlocationdetails = value;
                OnPropertyChanged();
            }
        }

        public LocationScoreDetails _selectedlocationdetails { get; set; }
        public LocationScoreDetails selectedlocationdetails
        {
            get { return _selectedlocationdetails; }
            set
            {
                _selectedlocationdetails = value;
                OnPropertyChanged();
            }
        }

        public async void getlocationcrimeDetails()
        {
            if (this.selectedPinlocationdetails != null)
            {
                try
                {
                    string webURL = APIHelper.Selectedlocationfulldetails;
                    HttpHelper httpHelper = new HttpHelper();
                    var locationinfo = new Locationinfo_reqPara();
                    locationinfo.longitude = this.selectedPinlocationdetails.LONGITUDE;
                    locationinfo.latitude = this.selectedPinlocationdetails.LATITUDE;
                    APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(locationinfo));
                    if (res.success)
                    {
                        List<LocationfullDetails> details = new List<LocationfullDetails>();
                        var obj = JsonConvert.SerializeObject(res.data);
                        details = JsonConvert.DeserializeObject<List<LocationfullDetails>>(obj);
                        if (details[0] != null)
                        {
                            LocationScoreDetails temp = new LocationScoreDetails();
                            temp.ID = details[0].ID;
                            temp._id = details[0]._id;
                            temp.NAME = details[0].NAME;
                           temp.POPCY = details[0].POPCY;
                           temp.CRMCYTOTC = details[0].CRMCYTOTC.ToString();
                           temp.CRMCYPERC = details[0].CRMCYPERC.ToString();
                           temp.CRMCYMURD = details[0].CRMCYMURD.ToString();
                           temp.CRMCYRAPE = details[0].CRMCYRAPE.ToString();
                           temp.CRMCYROBB = details[0].CRMCYROBB.ToString();
                           temp.CRMCYASST = details[0].CRMCYASST.ToString();
                           temp.CRMCYPROC = details[0].CRMCYPROC.ToString();
                           temp.CRMCYBURG = details[0].CRMCYBURG.ToString();
                           temp.CRMCYLARC = details[0].CRMCYLARC.ToString();
                           temp.CRMCYMVEH = details[0].CRMCYMVEH.ToString();
                           this._selectedlocationdetails = temp;
                           this.selectedlocationdetails = temp;
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("", "Location crime details not available,you may rate it now!", "OK");
                        }
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
            else
            {
                await App.Current.MainPage.DisplayAlert("", "Location crime details not available,you may rate it now!", "OK");
            }
        }

        public SelectedLocationfullDetailsVM()
		{
            backbtnAction = new BackbtnActionCommand(this);
		}
        public void popupViewAsync()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }

    public class BackbtnActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SelectedLocationfullDetailsVM VM;

        public BackbtnActionCommand(SelectedLocationfullDetailsVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.popupViewAsync();
        }

    }

}

