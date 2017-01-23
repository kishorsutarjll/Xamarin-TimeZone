
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TimeZone
{
	public class CountryListAdapter : BaseAdapter<CountryDetails>
	{
		List<CountryDetails> items;
		Activity context;

		public CountryListAdapter(Activity context, List<CountryDetails> items)
       : base()
   {
			this.context = context;
			this.items = items;
		}

		public override CountryDetails this[int position]
		{
			get
			{
				 return items[position]; 
			}
		}

		public override int Count
		{
			get
			{
				return items.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var item = items[position];
			View view = convertView;
			if (view == null) // no view to re-use, create new
				view = context.LayoutInflater.Inflate(Resource.Layout.CountryDetailRow, null);
			view.FindViewById<TextView>(Resource.Id.country_name).Text = item.countryName;
			view.FindViewById<TextView>(Resource.Id.country_time).Text = item.countryTime;
			view.FindViewById<ImageView>(Resource.Id.country_flag).SetImageResource(item.countryFlagUrl);
			//view.FindViewById<ImageView>(Resource.Id.country_flag).SetImageResource(item.countryFlagUrl);
			return view;

		}
	}
}
