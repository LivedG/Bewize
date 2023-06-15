using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bewize.Models
{
    public class MyRatings
    {
        public String Title { get; set; }
        public Double Starcount { get; set; }
        public String Address { get; set;}
        public String Posttiming { get; set; }
        public Double overallSafety_ratings { get; set; }
        public String cleanlinees_ratings { get; set; }
        public String Lighting_ratings { get; set; }
        public String Suspicious_ratings { get; set; }
        public String Vagrancy_ratings { get; set; }
        public String Comment { get; set; }
       

	}

    public class CrimeType
    {
          public String _id { get; set; }
          public String lebal { get; set; }
          public String desc { get; set; }
          public String is_active { get; set; }
          public String createdAt { get; set; }
          public String updatedAt { get; set; }
          public String __v { get; set; }

       
    }

    public class MyRatingsDetails
    {
        public String latitude { get; set; }
        public String longitude { get; set; }
        public String name { get; set; }
        public String updatedAt { get; set; }
        public List<Submittedrating> my_ratings { get; set; }
    }

    public class SubmittedratingList
    {
        public List<Submittedrating> my_ratings { get; set; }
        
    }

    public class Submittedrating
    {
        public String title { get; set; }
        public String rating { get; set; }
        public String crime_type { get; set; }

    }


}

