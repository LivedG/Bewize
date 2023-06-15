using System;
using Bewize.Models;
using Newtonsoft.Json;
using SQLite;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
//using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Linq;

namespace Bewize.HelperResource
{
	public class MapHelper
	{
       
        public MapHelper()
		{

        }

        //public async Task<Position> GetLocationdetailsbyZipcode(string Zipcode)
        //{
        //    Geocoder geoCoder = new Geocoder();
        //    Position position = new Position();
        //    try
        //    {
        //        IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(Zipcode);
        //        position = approximateLocations.FirstOrDefault();
        //        string coordinates = $"{position.Latitude}, {position.Longitude}";
        //        return position;
        //    }
        //    catch (Exception ex)
        //    {

        //        return position;
        //    }
        //}
    }
}

