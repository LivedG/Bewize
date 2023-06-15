using System;
using System.Collections.Generic;
using Bewize.ViewModels;
using Xamarin.Forms;

namespace Bewize.Views.MyRating
{	
	public partial class CrimeTypePopupPage : ContentPage
	{
        CrimeTypePopupVM VM;
        bool islistvisible = false;
		public CrimeTypePopupPage ()
		{
			InitializeComponent ();
            VM = new CrimeTypePopupVM();
            BindingContext = VM;
            VM.OverWindowheight = 240;
            VM.listviewheight = 0;

		}


        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.getCrimetypelistfromserver();
        }

        public void dropdownbtn_Clicked(System.Object sender, System.EventArgs e)
        {
         if (this.islistvisible == true)
            {
                VM.Crimetypelistvisible(false);
                this.islistvisible = false;
            }
            else {
                VM.Crimetypelistvisible(true);
                this.islistvisible = true;
            }

        }

        public void Donebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            VM.MoveBackwardScreen();
        }

        public void Crimelist_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (this.islistvisible == true)
            {
                VM.Crimetypelistvisible(false);
                this.islistvisible = false;
            }
            else
            {
                VM.Crimetypelistvisible(true);
                this.islistvisible = true;
            }
            if (VM.SelectedCrimetype != null) {
                Crimetypetxt.Text = VM.SelectedCrimetype.lebal;
            }
        }
    }
}

