﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using SQLite;
using Newtonsoft.Json.Linq;
using Xamarin.Forms.GoogleMaps;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Forms.Maps;

namespace Bewize.Models
{
	public class APIResponse
	{
        public bool success { get; set; }
        public string message { get; set; }
        public object response { get; set; }
		public int statusCode { get; set; }
		public string token { get; set; }
        public object data { get; set; }
        public object user { get; set; }
        public string otp { get; set; }

        public APIResponse()
		{
		}
	}


    public class GooglePlaceAutoCompletePrediction
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("structured_formatting")]
        public StructuredFormatting StructuredFormatting { get; set; }

    }

    public class StructuredFormatting
    {
        [JsonProperty("main_text")]
        public string MainText { get; set; }

        [JsonProperty("secondary_text")]
        public string SecondaryText { get; set; }
    }

    public class GooglePlaceAutoCompleteResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("predictions")]
        public List<GooglePlaceAutoCompletePrediction> AutoCompletePlaces { get; set; }
    }

    public class GooglePlace
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Raw { get; set; }

        public GooglePlace(JObject jsonObject)
        {
            Name = (string)jsonObject["result"]["name"];
            Latitude = (double)jsonObject["result"]["geometry"]["location"]["lat"];
            Longitude = (double)jsonObject["result"]["geometry"]["location"]["lng"];
            Raw = jsonObject.ToString();
        }
    }
    public class OverviewPolyline
    {

        [JsonProperty("points")]
        public string Points { get; set; }
    }

    public class Route
    {

        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }

        [JsonProperty("copyrights")]
        public string Copyrights { get; set; }

        [JsonProperty("legs")]
        public IList<Leg> Legs { get; set; }

        [JsonProperty("overview_polyline")]
        public OverviewPolyline OverviewPolyline { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("warnings")]
        public IList<object> Warnings { get; set; }

        [JsonProperty("waypoint_order")]
        public IList<object> WaypointOrder { get; set; }
    }
    public class Step
    {

        [JsonProperty("distance")]
        public DistanceOp Distance { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("end_location")]
        public EndLocation EndLocation { get; set; }

        [JsonProperty("html_instructions")]
        public string HtmlInstructions { get; set; }

        [JsonProperty("polyline")]
        public Polyline Polyline { get; set; }

        [JsonProperty("start_location")]
        public StartLocation StartLocation { get; set; }

        [JsonProperty("travel_mode")]
        public string TravelMode { get; set; }

        [JsonProperty("maneuver")]
        public string Maneuver { get; set; }
    }

    public class Polyline
    {

        [JsonProperty("points")]
        public string Points { get; set; }
    }

    public class Leg
    {

        [JsonProperty("distance")]
        public DistanceOp Distance { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("end_address")]
        public string EndAddress { get; set; }

        [JsonProperty("end_location")]
        public EndLocation EndLocation { get; set; }

        [JsonProperty("start_address")]
        public string StartAddress { get; set; }

        [JsonProperty("start_location")]
        public StartLocation StartLocation { get; set; }

        [JsonProperty("steps")]
        public IList<Step> Steps { get; set; }

        [JsonProperty("traffic_speed_entry")]
        public IList<object> TrafficSpeedEntry { get; set; }

        [JsonProperty("via_waypoint")]
        public IList<object> ViaWaypoint { get; set; }
    }

    public class GeocodedWaypoint
    {
        [JsonProperty("geocoder_status")]
        public string GeocoderStatus { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("types")]
        public IList<string> Types { get; set; }
    }

    public class Northeast
    {

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class Southwest
    {

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class Bounds
    {

        [JsonProperty("northeast")]
        public Northeast Northeast { get; set; }

        [JsonProperty("southwest")]
        public Southwest Southwest { get; set; }
    }

    public class DistanceOp
    {

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class Duration
    {

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class EndLocation
    {

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class StartLocation
    {

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class GoogleDirection
    {

        [JsonProperty("geocoded_waypoints")]
        public IList<GeocodedWaypoint> GeocodedWaypoints { get; set; }

        [JsonProperty("routes")]
        public IList<Route> Routes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}

