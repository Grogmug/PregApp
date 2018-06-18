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
    public class StoreItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Purchased { get; set; }
        public int PictureId { get; set; }

        public StoreItem(string name, int price, int pictureId)
        {
            Name = name;
            Price = price;
            PictureId = pictureId;
            Purchased = false;
        }
    }
}