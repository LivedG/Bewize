using System;
using System.Collections.Generic;
using Bewize.Models;

using Xamarin.Forms;

namespace Bewize.Views.Home
{	
	public partial class MyHomepage : FlyoutPage
	{

		public MyHomepage ()
		{
            InitializeComponent();
			
            MenuPage = new MenuPage();
            Flyout = MenuPage;
            
            Detailview = new Homepagewith_zipcode();
            Detail = Detailview;

			MenuPage.ListView.ItemSelected += OnItemSelected;
            MenuPage.Closebtn.Clicked += Closebtn_Clicked;

            Detailview.Hambugermenubtn.Clicked += Hambugermenubtn_Clicked;
            
        }

       

        private void Hambugermenubtn_Clicked(object sender, EventArgs e)
        {
            IsPresented = true;
        }

        private void Closebtn_Clicked(object sender, EventArgs e)
        {
           IsPresented = false;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutitemPage;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.Targetpage));
                MenuPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}

