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
    [Activity(Label = "StoreActivity")]
    public class StoreActivity : Activity
    {
        GlobalVariables gv;
        TextView score;
        ListView storeListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Store);

            // Toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            gv = GlobalVariables.Instance;

            score = FindViewById<TextView>(Resource.Id.storeScoreText);
            storeListView = FindViewById<ListView>(Resource.Id.storeListView);

            Updatestats();

            StoreAdapter adapter = new StoreAdapter(this, gv.storeItemList);
            storeListView.Adapter = adapter;

        }
        protected override void OnResume()
        {
            base.OnResume();
            Updatestats();

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

        public void Updatestats()
        {
            score.Text = gv.Score.ToString() + " points";
        }
    }
}