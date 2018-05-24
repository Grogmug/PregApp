﻿using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Views;
using Android.Preferences;
using Android.Hardware;
using UITesting.Models;
using Android.Content.PM;
using Android.Runtime;

namespace UITesting
{
    [Activity(Label = "UITesting", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait )]
    public class MainActivity : Activity, ISensorEventListener
    {
        ISharedPreferences prefs;
        SensorManager sensorManager;
        Sensor sensor;
        ImageButton runButton;
        ImageButton adviseButton;
        TextView usernameText;
        TextView scoreText;
        TextView steps;
        TextView km;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Check if user has a username
            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            if (!prefs.GetBoolean("first_time_setup", false))
            {
                var PreMainActivity = new Intent(this, typeof(PreMainActivity));
                this.StartActivity(PreMainActivity);
            }

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //4 Menu buttons
            runButton = FindViewById<ImageButton>(Resource.Id.runButton);
            adviseButton = FindViewById<ImageButton>(Resource.Id.adviseButton);

            runButton.Click += OpenRunMenu;
            adviseButton.Click += OpenAdviseMenu;

            //ToolBar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "PregApp";

            //Username
            usernameText = FindViewById<TextView>(Resource.Id.usernameText);
            usernameText.Text = prefs.GetString("username", "username");

            //score
            scoreText = FindViewById<TextView>(Resource.Id.scoreText);

            //Steps
            sensorManager = (SensorManager)GetSystemService(Context.SensorService);
            sensor = sensorManager.GetDefaultSensor(SensorType.StepCounter);
            steps = FindViewById<TextView>(Resource.Id.stepsText);
            km = FindViewById<TextView>(Resource.Id.kmText);

            steps.Click += AddSteps;
        }

        protected override void OnResume()
        {
            base.OnResume();
            usernameText.Text = prefs.GetString("username", "username");
            scoreText.Text = GlobalVariables.Instance.Score.ToString();
            sensorManager.RegisterListener(this, sensor, SensorDelay.Ui);
        }

        private void AddSteps(object sender, EventArgs e)
        {
            GlobalVariables.Instance.Steps += 525;
            steps.Text = GlobalVariables.Instance.Steps + " steps";
            UpdateStats();
        }

        private void UpdateStats()
        {
            steps.Text = GlobalVariables.Instance.Steps.ToString();
            km.Text = string.Format("{0:0.00} km", GlobalVariables.Instance.Steps / 1312.0);
        }


        private void OpenAdviseMenu(object sender, EventArgs e)
        {
            var adviseActivity = new Intent(this, typeof(AdviceActivity));
            this.StartActivity(adviseActivity);
        }

        private void OpenRunMenu(object sender, EventArgs e)
        {
            var runActivity = new Intent(this, typeof(TaskActivity));
            this.StartActivity(runActivity);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.TopMenu , menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var settingsActivity = new Intent(this, typeof(SettingsActivity));
            this.StartActivity(settingsActivity);
            return base.OnOptionsItemSelected(item);
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            
        }

        public void OnSensorChanged(SensorEvent e)
        {
            GlobalVariables.Instance.Steps = (int)e.Values[0];
            UpdateStats();
        }
    }
}

