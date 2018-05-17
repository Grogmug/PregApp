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
        GlobalVariables gv;
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

            gv = GlobalVariables.Instance;

            taskListView = FindViewById<ListView>(Resource.Id.taskListView);

            UpdateTaskList();

            TasksAdapter adapter = new TasksAdapter(this, gv.taskList);

            taskListView.Adapter = adapter;


        }

        //protected override void OnResume()
        //{
        //    UpdateTaskList();

        //    base.OnResume();
        //}
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

        public void UpdateTaskList()
        {
            for (int i = gv.taskList.Count - 1; i >= 0; i--)
            {
                gv.taskList[i].Progress = gv.Steps;
                if (gv.taskList[i].Completed == true)
                {
                    gv.Score += gv.taskList[i].Points;
                    gv.taskList.RemoveAt(i);
                }
            }
            TasksAdapter adapter = new TasksAdapter(this, gv.taskList);

            taskListView.Adapter = adapter;
        }
    }
}