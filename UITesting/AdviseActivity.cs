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
using UITesting.Models;

namespace UITesting
{
    [Activity(Label = "AdviceActivity")]
    public class AdviceActivity : Activity
    {
        List<Advice> adviceList;
        ListView adviceListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Advice);

            // Toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            adviceList = new List<Advice>() {new Advice("Sunde mellemmåltider", "Det er vigtigt at få nogle mellemmåltider, men men det er også vigtigt at de så er sunde, vi anbefalder derfor nogle frugt og grønt."),
                new Advice("fipflap", "flip flup flap wakka wakka wakka wakka"),
            new Advice("Test", "test"),new Advice("Test", "test"),new Advice("Test", "test"),new Advice("Test", "test"),new Advice("Test", "test"),new Advice("Test", "test"),new Advice("Test", "test"),new Advice("Test", "test")};

            adviceListView = FindViewById<ListView>(Resource.Id.adviceListView);

            AdviseAdapter adapter = new AdviseAdapter(this, adviceList);

            adviceListView.Adapter = adapter;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}