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
    public class SettingsAdapter : BaseAdapter
    {
        Activity activity;
        List<StoreItem> settingsList;
        LayoutInflater inflate;
        GlobalVariables gv;

        public SettingsAdapter(Activity activity, List<StoreItem> settingsList)
        {
            this.activity = activity;
            this.settingsList = settingsList;
            inflate = LayoutInflater.FromContext(activity);
        }

        public override int Count { get { return settingsList.Count; } }

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
            var view = convertView ?? inflate.Inflate(Resource.Layout.SettingsListItem, parent, false);
            var title = view.FindViewById<TextView>(Resource.Id.SettingsItemTitle);
            var image = view.FindViewById<ImageView>(Resource.Id.SettingsItemImage);
            var button = view.FindViewById<Button>(Resource.Id.SettingsItemButton);

            title.Text = settingsList[position].Name;
            image.SetImageResource(settingsList[position].PictureId);
            button.Text = "Vælg";
            button.Tag = position;
            button.Click += EquipItemClick;
            return view;
        }

        private void EquipItemClick(object sender, EventArgs e)
        {
            gv = GlobalVariables.Instance;
            Button buttonTag = (Button)sender;
            gv.PictureId = settingsList[(int)buttonTag.Tag].PictureId;
        }
    }
}