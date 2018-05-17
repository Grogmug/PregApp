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
    public class TasksAdapter : BaseAdapter
    {
        Activity activity;
        List<Task> taskList;
        LayoutInflater inflate;
        public TasksAdapter(Activity activity, List<Task> taskList)
        {
            this.activity = activity;
            this.taskList = taskList;
            inflate = LayoutInflater.FromContext(activity);
        }
        public override int Count { get { return taskList.Count; } }

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
                Resource.Layout.TaskListItem, parent, false);
            var title= view.FindViewById<TextView>(Resource.Id.titleText);
            var disc = view.FindViewById<TextView>(Resource.Id.discText);
            var points = view.FindViewById<TextView>(Resource.Id.pointText);
            var progressBar = view.FindViewById<ProgressBar>(Resource.Id.taskProgressBar);
            title.Text = taskList[position].Title;
            disc.Text = taskList[position].Discribtion;
            points.Text = taskList[position].Points.ToString();
            progressBar.Max = taskList[position].MaxAmount;
            progressBar.Progress = taskList[position].Progress;
            return view;
        }
    }
}