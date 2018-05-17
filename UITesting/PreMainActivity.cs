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
    [Activity(Label = "PreMain")]
    public class PreMainActivity : Activity
    {
        ISharedPreferences prefs;
        ISharedPreferencesEditor editor;
        EditText input;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PreMain);

            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            editor = prefs.Edit();

            if (!prefs.GetBoolean("first_time_setup", false))
            {
                input = new EditText(this);
                AlertDialog.Builder alertBuilder = new AlertDialog.Builder(this);
                alertBuilder.SetTitle("Enter your Username");
                alertBuilder.SetView(input);
                alertBuilder.SetPositiveButton("Done", OnDoneClick);
                alertBuilder.Show();
            }
            else
                SwapToMainScreen();

            
        }


        private void OnDoneClick(object sender, DialogClickEventArgs args)
        {
            editor.PutBoolean("first_time_setup", true);
            editor.PutString("username", input.Text);
            editor.Apply();

            SwapToMainScreen();
        }

        private void SwapToMainScreen()
        {
            Finish();
        }

        public override void OnBackPressed()
        {

        }
    }
}