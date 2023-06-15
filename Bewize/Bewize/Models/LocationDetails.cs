
using System;
using System.Collections.Generic;

namespace Bewize.Models
{
    public class LocationScoreDetails
    {

        public string _id { get; set; }
        public string ID { get; set; }
        public string NAME { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string POPCY { get; set; }
        public string CRMCYTOTC { get; set; }
        public string CRMCYPERC { get; set; }
        public string CRMCYMURD { get; set; }
        public string CRMCYRAPE { get; set; }
        public string CRMCYROBB { get; set; }
        public string CRMCYASST { get; set; }
        public string CRMCYPROC { get; set; }
        public string CRMCYBURG { get; set; }
        public string CRMCYLARC { get; set; }
        public string CRMCYMVEH { get; set; }
        public List<string> CORDINATES { get; set; }
        public string updatedAt { get; set; }

        public LocationScoreDetails()
        {
        }
    }

    public class LocationfullDetails
    {

        public string _id { get; set; }
        public string ID { get; set; }
        public string NAME { get; set; }
        public string POPCY { get; set; }
        public int CRMCYTOTC { get; set; }
        public int CRMCYPERC { get; set; }
        public int CRMCYMURD { get; set; }
        public int CRMCYRAPE { get; set; }
        public int CRMCYROBB { get; set; }
        public int CRMCYASST { get; set; }
        public int CRMCYPROC { get; set; }
        public int CRMCYBURG { get; set; }
        public int CRMCYLARC { get; set; }
        public int CRMCYMVEH { get; set; }

        public LocationfullDetails()
        {
        }
    }
}