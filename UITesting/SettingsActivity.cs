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
using Android.Preferences;

namespace UITesting
{
    [Activity(Label = "Settings")]
    public class SettingsActivity : Activity
    {
        ISharedPreferences prefs;
        ISharedPreferencesEditor editor;
        EditText changeUsernameText;
        Button apply;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Settings);

            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            editor = prefs.Edit();

            // Toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            apply = FindViewById<Button>(Resource.Id.SaveSettings);

            apply.Click += ApplyChanges;
        }

        private void ApplyChanges(object sender, EventArgs e)
        {
            changeUsernameText = FindViewById<EditText>(Resource.Id.ChangeUsernameText);
            if (changeUsernameText.Text.Length >= 4)
            {
                editor.PutString("username", changeUsernameText.Text);
                editor.Apply();
                Toast.MakeText(this, "Changes have been applied", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Username too short", ToastLength.Short).Show();
            }
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