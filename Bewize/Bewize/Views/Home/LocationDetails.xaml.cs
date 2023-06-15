using System;
using System.Collections.Generic;
using Bewize.Models;
using Xamarin.Forms;

namespace Bewize.Views.Home
{	
	public partial class LocationDetails : Rg.Plugins.Popup.Pages.PopupPage
    {	
		public LocationDetails ()
		{
            InitializeComponent();
        }

        public static implicit operator LocationDetails(LocationScoreDetails v)
        {
            throw new NotImplementedException();
        }
    }
}

