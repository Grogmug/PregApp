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

        //Dummy task items
        public List<Task> taskList = new List<Task>() {
                new Task("Gå 3000 skridt", "Gå en lille tur for at få noget motion og frisk luft.", 3000, 50),
                new Task("Gå 10000 skridt", "I løbet af dagen gå 10000skridt.",10000,100),
                new Task("20000", "Test text",20000,200),
                new Task("100000", "Test text",100000,1000) };

}
}