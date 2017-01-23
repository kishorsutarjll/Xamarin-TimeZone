
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TimeZone
{
	[Activity(Label = "TimeZone", MainLauncher = true, Icon = "@mipmap/icon")]
	public class TimeZoneActivity : Activity
	{
		ListView listView;
		[Android.Runtime.Register("ACTION_TIME_TICK")]
		public const String ActionTimeTick = "android.intent.action.ACTION_TIME_TICK";
		List<CountryDetails> countryItems = new List<CountryDetails>();
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			TimerBroadcastReceiver reciver = new TimerBroadcastReceiver();
			IntentFilter filter = new IntentFilter(ActionTimeTick);
			RegisterReceiver(reciver, filter);


			// Create your application here
			SetContentView(Resource.Layout.timezone);
			listView = FindViewById<ListView>(Resource.Id.zoneListView); // get reference to the ListView in the layout
																		 // populate the listview with data

			getCountryDetails();

			listView.Adapter = new CountryListAdapter(this, countryItems);
			listView.ItemClick += OnListItemClick;  // to be defined

		}
		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			//var listView = sender as ListView;
			var t = countryItems[e.Position];
			Android.Widget.Toast.MakeText(this, t.countryName, Android.Widget.ToastLength.Short).Show();
		}

		private void getCountryDetails() {
			
			countryItems.Add(getAmericaZoneObject());

			countryItems.Add(getSingaporeZoneObject());
		
			countryItems.Add(getIndiaZoneObject());
		
			countryItems.Add(getVietnamZoneObject());


			//TimeZoneInfo timeZone;
			//try
			//{
			//	//timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Chicago");
			//	//timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Kolkata");
			//	//Asia / Calcutta
			//	//timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Singapore");
			//	//timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Vientiane");
			//	timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");

			//}
			//catch (Exception)
			//{
			//	timeZone = TimeZoneInfo.Local;
			//}
			//DateTime now = DateTime.Now.ToLocalTime();
			//var time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, timeZone.Id);
			//Console.WriteLine("Time Zone : {0}",time);

		}

		private CountryDetails getAmericaZoneObject() { 
		
		CountryDetails detailAmerica = new CountryDetails();
			TimeZoneInfo timeZone;
			try
			{
				timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Chicago");
			

			}
			catch (Exception)
			{
				timeZone = TimeZoneInfo.Local;
			}
			DateTime now = DateTime.Now.ToLocalTime();
			var time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, timeZone.Id);
			Console.WriteLine("Time Zone : {0}", time);
			detailAmerica.countryName = "America/Chicago";
			detailAmerica.countryTime = time.ToString("dd/MM/yyyy") + " " + time.ToShortTimeString();
			detailAmerica.countryFlagUrl = Resource.Drawable.america;
			return detailAmerica;
		}

		private CountryDetails getIndiaZoneObject()
		{

			CountryDetails detailIndia = new CountryDetails();
			TimeZoneInfo timeZone;
			try
			{
	
				timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Kolkata");
	

			}
			catch (Exception)
			{
				timeZone = TimeZoneInfo.Local;
			}
			DateTime now = DateTime.Now.ToLocalTime();
			var time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, timeZone.Id);
			detailIndia.countryName = "India";
			detailIndia.countryTime = time.ToString("dd/MM/yyyy") + " " + time.ToShortTimeString();
			detailIndia.countryFlagUrl = Resource.Drawable.india;
			return detailIndia;
		}

		private CountryDetails getSingaporeZoneObject()
		{

			CountryDetails detailSingapore = new CountryDetails();
			TimeZoneInfo timeZone;
			try
			{
		
				timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Singapore");


			}
			catch (Exception)
			{
				timeZone = TimeZoneInfo.Local;
			}
			DateTime now = DateTime.Now.ToLocalTime();
			var time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, timeZone.Id);
			Console.WriteLine("Time Zone : {0}", time);
			detailSingapore.countryName = "Singapore";
			detailSingapore.countryTime = time.ToString("dd/MM/yyyy") + " " + time.ToShortTimeString();
			detailSingapore.countryFlagUrl = Resource.Drawable.singapore;
			return detailSingapore;
		}

		private CountryDetails getVietnamZoneObject()
		{

			CountryDetails detailVietnam = new CountryDetails();
			TimeZoneInfo timeZone;
			try
			{
				
				timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Ho_Chi_Minh");

			}
			catch (Exception)
			{
				timeZone = TimeZoneInfo.Local;
			}
			DateTime now = DateTime.Now.ToLocalTime();
			var time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(now, timeZone.Id);
			Console.WriteLine("Time Zone : {0}", time);
			detailVietnam.countryName = "Vietnam";
			detailVietnam.countryTime = time.ToString("dd/MM/yyyy")+ " "+ time.ToShortTimeString();
			detailVietnam.countryFlagUrl = Resource.Drawable.vietnam;
			return detailVietnam;
		}
	}
}
