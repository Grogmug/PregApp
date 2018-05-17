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
using Java.Lang;
using UITesting.Models;

namespace UITesting
{
    public class AdviseAdapter : BaseAdapter
    {
        Activity activity;
        List<Advice> adviceList;
        LayoutInflater inflate;

        public AdviseAdapter(Activity activity, List<Advice> adviseList)
        {
            this.activity = activity;
            this.adviceList = adviseList;
            inflate = LayoutInflater.FromContext(activity);
        }
        public override int Count { get { return adviceList.Count; } }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? inflate.Inflate(
    Resource.Layout.AdviceListItem, parent, false);
            var title = view.FindViewById<TextView>(Resource.Id.adviceTitleText);
            var disc = view.FindViewById<TextView>(Resource.Id.adviceTextText);
            title.Text = adviceList[position].AdviceTitle;
            disc.Text = adviceList[position].AdviceText;

            return view;
        }
    }
}