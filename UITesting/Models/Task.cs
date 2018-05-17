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
        public bool Completed { get { return Progress >= MaxAmount; } }
        public int MaxAmount { get; set; }
        public int Progress { get; set; }
        public int Points { get; set; }

        public Task(string title, string disc, int maxAmount, int points)
        {
            Title = title;
            Discribtion = disc;
            MaxAmount = maxAmount;
            Points = points;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}