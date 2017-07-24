using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace AppMeetings
{
    public partial class Geolocator : ContentPage
    {
        public Geolocator()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            Task.WaitAll();
            string lattitude = position.Latitude.ToString();
            string longitude = position.Longitude.ToString();
            DisplayAlert("Summer Trainning", "The current lattitude is " + lattitude + " and longitude " + longitude,
                "OK");

        }
    }
}
