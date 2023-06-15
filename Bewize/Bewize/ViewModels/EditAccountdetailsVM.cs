using System;
using System.Windows.Input;
using Bewize.Views;
using Bewize.Models;
using Bewize.HelperResource;
using SQLite;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Auth;
using Xamarin.Essentials;
using System.Linq;
using Bewize.Views.Signup_Login;
using Rg.Plugins.Popup.Services;

namespace Bewize.ViewModels
{
    public class EditAccountdetailsVM : BaseViewModel
    {
        //public SavebtnCommand Savebtn_Command { get; set; }
        public EditAC_ChangepwdbtnCommand EditAcChangepwd_command { get; set; }
        public EditBackbtn_Command EditBackbtn_Cmd { get; set; }


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

        private Country _SelectedCountry;
        public Country selectedCountry
        {
            get { return _SelectedCountry; }
            set
            {
                _SelectedCountry = value;
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



        public EditAccountdetailsVM()
        {
            EditBackbtn_Cmd = new EditBackbtn_Command(this);
            EditAcChangepwd_command = new EditAC_ChangepwdbtnCommand(this);
            selectedCountry = new Country();
        }

        public async void setProfiledata(UserDetails userDetails) {

            this.Profiledetails = new UserDetails();
            this.Profiledetails = userDetails;
            if(this.Profiledetails != null) {
                if (Profiledetails.profile_img != "" && Profiledetails.profile_img != null)
                {
                        MessagingCenter.Send<object, string>(this, "Profilepic", Profiledetails.profile_img);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Please fill your acccount details for better experience.", "OK");
                }
            }
        }

        public async void ProfiledetailsupdateSucesfully(Updateduserdetails profiledata)
        {
            try
            {
                string webURL = APIHelper.Updateuserdetails;
                HttpHelper httpHelper = new HttpHelper();

                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(profiledata));

                if (res.success)
                {
                    UserDetails details = new UserDetails();
                    string obj = JsonConvert.SerializeObject(res.data);
                    details = JsonConvert.DeserializeObject<UserDetails>(obj);
                    this.UpdateStoreusertoLocaldb(details, res.token);
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                    await App.Current.MainPage.Navigation.PopAsync();
                    // 
                }
                else
                {
                    message = res.message;
                    // isActivity = false;
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
            }
            catch (Exception ex)
            {
                // isActivity = false;
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");

            }


        }


        public async void Update_profilepicture(Byte[] profilepicbytedata)
        {

            try
            {

                string webURL = APIHelper.UploadProfileimage;
                HttpHelper httpHelper = new HttpHelper();

                APIResponse res = await httpHelper.Multiforn_callAPI(webURL, profilepicbytedata);

                if (res.success)
                {
                    UserDetails details = new UserDetails();
                    string obj = JsonConvert.SerializeObject(res.data);
                    details = JsonConvert.DeserializeObject<UserDetails>(obj);
               
                }
                else
                {
                    message = res.message;
                    // isActivity = false;
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
            }
            catch (Exception ex)
            {
                // isActivity = false;
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");

            }
            App.Current.MainPage.Navigation.PopAsync();

        }

        public async void UpdateStoreusertoLocaldb(UserDetails udetails, string token)
        {
           
            var localuser = await App.SQLiteDb.GetItemAsync(udetails._id);
            if (localuser != null)
            {
                await App.SQLiteDb.UpdateItemAsync(udetails);
            }
        }
        public void MoveForwardtoChangepwd()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Profile.Acc_NumberverificationPage());
        }

        public async void CountrycodeselectionAsync()
        {
            var countrypopuppage = new CountyCodeSelectionPage();
            countrypopuppage.SelectedCountrySet += this.OncountrySeletion;
           
            await PopupNavigation.Instance.PushAsync(countrypopuppage);
        }

        public async void Checkfornumberdublication(string countrycode,string number)
        {
            Sendotp_reqPara reqpara = new Sendotp_reqPara();
            reqpara.phone = number;
            reqpara.country_code = countrycode;
            try
            {

                string webURL = APIHelper.VerifyPhone;
                HttpHelper httpHelper = new HttpHelper();
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(reqpara));

                if (res.success)
                {
                 
                }
                else
                {
                    message = res.message;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }
        }

        public void OncountrySeletion(object source, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("{0} ", selectedCountry);
           // this.selectedCountry = selectedCountry.country_code;
            App.Current.MainPage.Navigation.PopAsync();
        }
        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }

    public class EditBackbtn_Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private EditAccountdetailsVM VM;

        public EditBackbtn_Command(EditAccountdetailsVM vm)
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


    public class EditAC_ChangepwdbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private EditAccountdetailsVM VM;

        public EditAC_ChangepwdbtnCommand(EditAccountdetailsVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveForwardtoChangepwd();
        }
    }


   
}

