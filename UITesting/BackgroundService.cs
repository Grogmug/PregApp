using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Hardware;
using UITesting.Models;

namespace UITesting
{
    [Service]
    public class BackgroundService : Service, ISensorEventListener
    {
        SensorManager sensorManager;
        Sensor sensor;
        Notification notification;
        NotificationManager notificationManager;
        GlobalVariables gv;

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            gv = GlobalVariables.Instance;
            //sensor
            sensorManager = (SensorManager)GetSystemService(Context.SensorService);
            sensor = sensorManager.GetDefaultSensor(SensorType.StepCounter);
            sensorManager.RegisterListener(this, sensor, SensorDelay.Ui);

            //Notification
            Console.WriteLine("Logging");
            Notification.Builder builder = new Notification.Builder(this)
            .SetContentTitle("Goal reached!")
            .SetContentText("You just reached a goal, keep up the good work!")
            .SetSmallIcon(Resource.Drawable.Pixel_baby);

            // Build the notification:
            notification = builder.Build();

            // Get the notification manager:
            notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            return StartCommandResult.Sticky;
        }
        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {

        }

        public void OnSensorChanged(SensorEvent e)
        {
            GlobalVariables.Instance.Steps = (int)e.Values[0];

            for (int i = gv.taskList.Count - 1; i >= 0; i--)
            {
                gv.taskList[i].Progress = gv.Steps;
                if (gv.taskList[i].Completed == true)
                {
                    gv.Score += gv.taskList[i].Points;
                    gv.taskList.RemoveAt(i);
                    // Publish the notification:
                    const int notificationId = 0;
                    notificationManager.Notify(notificationId, notification);
                }
            }
        }
    }
}