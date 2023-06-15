using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Bewize.Views.Home
{	
	public partial class LocationScore_RatingPage : ContentPage
	{	
		public LocationScore_RatingPage ()
		{
			InitializeComponent ();

            VisibleScoreview();
        }

        public void VisibleScoreview()
        {
            Scorebtn.BackgroundColor = Color.White;
            Scorebtn.TextColor = Color.CornflowerBlue;
            Ratingbtn.BackgroundColor = Color.Transparent;
            Ratingbtn.TextColor = Color.Gray;
            ScoreView.IsVisible = true;
            RatingView.IsVisible = false;

        }


        public void VisibleRatingview()
        {
            Scorebtn.BackgroundColor = Color.Transparent;
            Scorebtn.TextColor = Color.DarkGray;
            Ratingbtn.BackgroundColor = Color.White;
            Ratingbtn.TextColor = Color.CornflowerBlue;
            ScoreView.IsVisible = false;
            RatingView.IsVisible = true;
        }



        public void Scorebtn_Clicked(System.Object sender, System.EventArgs e)
        {
            VisibleScoreview();
        }

        public void Ratingbtn_Clicked(System.Object sender, System.EventArgs e)
        {
            VisibleRatingview();
        }
    }
}

