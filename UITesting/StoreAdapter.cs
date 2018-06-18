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
    public class StoreAdapter : BaseAdapter
    {
        Activity activity;
        List<StoreItem> storeList;
        LayoutInflater inflate;
        GlobalVariables gv;
        public StoreAdapter(Activity activity, List<StoreItem> storeList)
        {
            this.activity = activity;
            this.storeList = storeList;
            inflate = LayoutInflater.FromContext(activity);
        }
        public override int Count { get { return storeList.Count; } }

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
            var view = convertView ?? inflate.Inflate(Resource.Layout.StoreListItem, parent, false);
            var title = view.FindViewById<TextView>(Resource.Id.storeItemTitleText);
            var price = view.FindViewById<TextView>(Resource.Id.storeItemPriceText);
            var image = view.FindViewById<ImageView>(Resource.Id.storeItemImage);
            var button = view.FindViewById<Button>(Resource.Id.storeItemButton);
            button.Tag = position;
            title.Text = storeList[position].Name;
            price.Text = storeList[position].Price.ToString() + " points";
            image.SetImageResource(storeList[position].PictureId);
            if (storeList[position].Purchased == false)
            {
                button.Click += BuyItemClick;
                button.Text = "Køb";
            }
            else
            {
                button.Enabled = false;
            }
            
            return view;
        }

        private void BuyItemClick(object sender, EventArgs e)
        {
            gv = GlobalVariables.Instance;
            Button buttonTag = (Button)sender;
            if (gv.Score >= storeList[(int)buttonTag.Tag].Price)
            {
                storeList[(int)buttonTag.Tag].Purchased = true;
                gv.Score -= storeList[(int)buttonTag.Tag].Price;
            }
        }
    }
}