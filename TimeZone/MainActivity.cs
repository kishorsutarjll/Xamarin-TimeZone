﻿using System;
using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Json;

namespace TimeZone
{
	//[Activity(Label = "TimeZone", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get the latitude/longitude EditBox and button resources:
			//EditText latitude = FindViewById<EditText>(Resource.Id.latText);
			//EditText longitude = FindViewById<EditText>(Resource.Id.longText);
			Button button = FindViewById<Button>(Resource.Id.getWeatherButton);

			// When the user clicks the button ...
			button.Click += async (sender, e) =>
			{
				string apiKey = "VWHMNOB7K8OK";
				// Get the latitude and longitude entered by the user and create a query.
				//string url = "http://api.geonames.org/findNearByWeatherJSON?lat=" +
			//-47	//latitude.Text +
				//"&lng=" +
			//122	//longitude.Text +
				//"&username=demo";

				string url = "http://api.timezonedb.com/v2/get-time-zone?key=" + apiKey + "&format=json&by=zone&zone=America/Chicago";
				//string url = "http://api.timezonedb.com/v2/get-time-zone?key=" + apiKey + "&format=json&by=zone&zone=Singapore/Singapore";

				// Fetch the weather information asynchronously, 
				// parse the results, then update the screen:
				JsonValue json = await FetchWeatherAsync(url);
				 ParseAndDisplay (json);
			};
		
		}

		// Gets weather data from the passed URL.
		private async Task<JsonValue> FetchWeatherAsync(string url)
		{
			// Create an HTTP web request using the URL:
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
			request.ContentType = "application/json";
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync())
			{
				// Get a stream representation of the HTTP web response:
				using (Stream stream = response.GetResponseStream())
				{
					// Use this stream to build a JSON document object:
					JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
					Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

					// Return the JSON document:
					return jsonDoc;
				}
			}
		}

		// Parse the weather data, then write temperature, humidity, 
		// conditions, and location to the screen.
		private void ParseAndDisplay(JsonValue json)
		{
			// Get the weather reporting fields from the layout resource:
			TextView location = FindViewById<TextView>(Resource.Id.locationText);
			//TextView temperature = FindViewById<TextView>(Resource.Id.tempText);
			//TextView humidity = FindViewById<TextView>(Resource.Id.humidText);
			//TextView conditions = FindViewById<TextView>(Resource.Id.condText);

			// Extract the array of name/value results for the field name "weatherObservation". 
			String weatherResults = json["formatted"];


			// Extract the "stationName" (location string) and write it to the location TextBox:
			location.Text = weatherResults;//["formatted"];

			// The temperature is expressed in Celsius:
			//double temp = weatherResults["temperature"];
			// Convert it to Fahrenheit:
			//temp = ((9.0 / 5.0) * temp) + 32;
			// Write the temperature (one decimal place) to the temperature TextBox:
			//temperature.Text = String.Format("{0:F1}", temp) + "° F";

			// Get the percent humidity and write it to the humidity TextBox:
			//double humidPercent = weatherResults["humidity"];
			//humidity.Text = humidPercent.ToString() + "%";

			// Get the "clouds" and "weatherConditions" strings and 
			// combine them. Ignore strings that are reported as "n/a":
			//string cloudy = weatherResults["clouds"];
			//if (cloudy.Equals("n/a"))
			//	cloudy = "";
			//string cond = weatherResults["weatherCondition"];
			//if (cond.Equals("n/a"))
			//	cond = "";

			// Write the result to the conditions TextBox:
			//conditions.Text = cloudy + " " + cond;
		}
	}


}

