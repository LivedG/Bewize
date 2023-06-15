using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Bewize.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using System.Linq;

namespace Bewize.Views.Signup_Login
{	
	public partial class CountyCodeSelectionPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        //PwdVerificationPage viewobj;
        //PwdVerificationVM vm;
        CountyCodeSelectionVM C_VM;

        private List<Country> Country_list { get; set; }
      


        public delegate void SetCountryselectionEventHandler(object source, EventArgs args);
        public event SetCountryselectionEventHandler SelectedCountrySet;


        public CountyCodeSelectionPage ()
		{
			InitializeComponent ();
          //  viewobj = new PwdVerificationPage();
            C_VM = new CountyCodeSelectionVM();
            BindingContext = C_VM;
            Countrylist.SelectedItem = 0;
           
        }


        protected override void OnAppearing()
        {
            C_VM.GetCountryListFromServer();
        }


            public async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            MessagingCenter.Send<object, Country>(this, "selectedcountry", C_VM.SelectedCountry);
            await PopupNavigation.Instance.PopAsync();
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                Countrylist.ItemsSource = C_VM.CountryList;
            }

            else
            {
                Countrylist.ItemsSource = C_VM.CountryList.Where(x => x.name.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }
        
    }
}

