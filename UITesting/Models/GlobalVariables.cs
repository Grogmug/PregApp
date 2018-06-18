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
    public class GlobalVariables
    {
        private static GlobalVariables instance;

        private GlobalVariables() { }

        public static GlobalVariables Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalVariables();
                }
                return instance;
            }
        }

        private int steps;
        private int km;
        private int score;
        private int pictureId;


        public int Steps
        {
            get { return steps; }
            set { steps = value; }
        }

        public int Km
        {
            get { return km; }
            set { km = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }


        public int PictureId
        {
            get { return pictureId; }
            set { pictureId = value; }
        }


        //Dummy task items
        public List<Task> taskList = new List<Task>() {
                new Task("Gå 50 skridt", "test test",50,50),
                new Task("Gå 3000 skridt", "Gå en lille tur for at få noget motion og frisk luft.", 3000, 50),
                new Task("Gå 5000 skridt", "I løbet af dagen gå 5000skridt.",5000,100),
                new Task("10000", "Test text",10000,100),
                new Task("20000", "Test text",20000,200),
                new Task("100000", "Test text",100000,1000)};
        // Dummy store items
        public List<StoreItem> storeItemList = new List<StoreItem>() {
                new StoreItem("Solbriller",50, Resource.Drawable.Pixel_baby_sunglasses),
                new StoreItem("Rød Hat",100, Resource.Drawable.Pixel_baby_red_hat),
                new StoreItem("Gul kasket",150, Resource.Drawable.Pixel_baby_yellow_cap)};


    }
}