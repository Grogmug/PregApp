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

namespace UITesting.Models
{
    public class Task
    {
        public string Title { get; set; }
        public string Discribtion { get; set; }
        public bool Completed { get; set; }

        public Task(string title, string disc)
        {
            Title = title;
            Discribtion = disc;
            Completed = false;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}