using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;

namespace Bewize.HelperResource
{
    public class UtilityHelper
    {
        public UtilityHelper()
        {
        }

        public static async Task<string> GetAddressFromLatLong(string latitude, string longitude)
        {
            Position currentposition = new Position(Convert.ToDouble(latitude), Convert.ToDouble(longitude));
            Geocoder geoCoder = new Geocoder();

            IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(currentposition);
            return possibleAddresses.FirstOrDefault();
        }

        public static string TimeDifference(string dateString)
        {
            DateTime startTime = DateTime.Now; //Current Date

            DateTime dateFromString = DateTime.Parse(dateString); //Parse the String to the DateTime

            //DateTime endTime = new DateTime(2021, 6, 8, 6, 01, 20);
            //Date in the(yyyy,dd,mm,hh,mm,ss) format

            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(startTime.Ticks - dateFromString.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}

