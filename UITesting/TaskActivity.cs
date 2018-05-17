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
    [Activity(Label = "TaskActivity")]
    public class TaskActivity : Activity
    {
        List<Task> taskList;
        ListView taskListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Tasks);
            // Toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            //Dummy task items
            taskList = new List<Task>() {
                new Task("Gå 2km", "Gå en lille tur for at få noget motion og frisk luft"),
                new Task("10 squats", "Lav 10 squats, hvor du løfter dit barn op imens."),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text"),
                new Task("Test", "Test text") };

            taskListView = FindViewById<ListView>(Resource.Id.taskListView);

            TasksAdapter adapter = new TasksAdapter(this, taskList);

            taskListView.Adapter = adapter;
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