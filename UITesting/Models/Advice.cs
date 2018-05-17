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
    public class Advice
    {
        public string AdviceTitle { get; set; }
        public string AdviceText { get; set; }

        public Advice(string title, string text)
        {
            AdviceTitle = title;
            AdviceText = text;
        }
    }
}