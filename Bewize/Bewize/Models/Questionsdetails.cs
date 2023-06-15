using System;
using System.Collections.Generic;


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
        public List<Questionsdetails> question { get; set; }
        public List<Answersdetails> anser { get; set; }

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
