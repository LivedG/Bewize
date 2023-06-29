using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bewize.Views.MyRating;

namespace Bewize.Models
{


    public class Questionsdetails
    {
        public string _id { get; set; }
        public int __v { get; set; }
        public string createdAt { get; set; }
        public bool is_active { get; set; }
        public List<string> option { get; set; }
        public string ans { get; set; }
        public string que { get; set; }
        public string crime_type { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string updatedAt { get; set; }
        public ObservableCollection<RatingSelected> ratings { get; set; } = new ObservableCollection<RatingSelected>()
        {
            new RatingSelected() { image = "Frustated.png",currentSelectedAns="1" },
            new RatingSelected() { image = "Sad.png" ,currentSelectedAns="2"},
            new RatingSelected() { image = "Neutral.png" ,currentSelectedAns="3"},
            new RatingSelected() { image = "Happy.png" ,currentSelectedAns="4"},
            new RatingSelected() { image = "Joyfull.png" ,currentSelectedAns="5"},
        };
    }

    public class RatingSelected
    {
        public string BGColor { get; set; } = MyRatingsProPg.unSelectedColor; // TO show image active or inactive set this proeprty
        public string image { get; set; }
        public string _id { get; set; }
        public string currentSelectedAns { get; set; }
    }

    public class Answersdetails
    {
        public string _id { get; set; }
        public int __v { get; set; }
        public bool is_active { get; set; }
        public string ans { get; set; }
        public string que { get; set; }
        public string crime_type { get; set; }
        public string type { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string createdby { get; set; }
        public string updatedby { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }


    public class Questionlistdetails
    {
        public string _id { get; set; }
        public ObservableCollection<Questionsdetails> question { get; set; }
        public ObservableCollection<Answersdetails> anser { get; set; }

    }

    public class SubmitAns_reqPara
    {
        public string ans { get; set; }
        public string que { get; set; }
        public string crime_type { get; set; }
        public string createdby { get; set; }
        public string updatedby { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class SubmitAnsList_reqPara
    {
        public List<SubmitAns_reqPara> ansList { get; set; }
    }

    public class getQuestionlist_reqPara
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}
