using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotifications;
using Plugin.Vibrate;
using Xamarin.Forms;

namespace AppMeetings
{
    public partial class Vibrate : ContentPage
    {
        public Vibrate()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Notification","Test Notification",1,DateTime.Now);

            CrossVibrate.Current.Vibration(TimeSpan.FromSeconds(10));        }
    }
}
