using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppMeetings.View
{
    public class MapPage : ContentPage
    {
        private Map map;
        public double Lattitude;
        public double Longitude;
        public  MapPage()
        {
            GetPositions();
            map = new Map
            {
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var position = new Position(Lattitude,Longitude);
            var pin = new Pin
            {
                Position = position,
                Address = "TEK-UP Adress",
                Label = "TEK-UP",
                Type = PinType.Place
            };
            var pos2 = new Position(36.9029481, 10.1452774);
            var pos3 = new Position(36.8608634, 10.1644176);
            var pos4 = new Position(36.8678495, 10.1712841);
            var pin2 = new Pin
            {
                Position = pos2,
                Address = "Location 2",
                Label = "TEK-UP",
                Type = PinType.Generic
            };
            var pin3 = new Pin
            {
                Position = pos3,
                Address = "Location 3",
                Label = "TEK-UP",
                Type = PinType.SavedPin
            };
            var pin4 = new Pin
            {
                Position = pos4,
                Address = "Location 4",
                Label = "TEK-UP",
                Type = PinType.SearchResult
            };
            map.Pins.Add(pin);
            map.Pins.Add(pin2);
            map.Pins.Add(pin3);
            map.Pins.Add(pin4);
            map.MoveToRegion(new MapSpan(position,360,360));
            var slider = new Xamarin.Forms.Slider(1,18,1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue;
                var degree = 360/(Math.Pow(2, zoomLevel));
                if (map.VisibleRegion != null)
                {
                    map.MoveToRegion(new MapSpan(map.VisibleRegion.Center,degree,degree));
                }
            };

            var streetBtn = new Button {Text = "Street" };

            var hybridBtn = new Button { Text = "Hybrid" };

           var steliteBtn = new Button {Text = "Satellite" };
            streetBtn.Clicked += ChangeViewMap;
            hybridBtn.Clicked += ChangeViewMap;
            steliteBtn.Clicked += ChangeViewMap;

            var stackBtn = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { streetBtn,hybridBtn,steliteBtn}               
            };
            var stackPage = new StackLayout {Spacing = 0};
            stackPage.Children.Add(map);
            stackPage.Children.Add(slider);
            stackPage.Children.Add(stackBtn);
            Content = stackPage;
          


        }

        private void ChangeViewMap(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street": 
                    map.MapType = MapType.Street;
                    break;
                case "Hybrid":
                    map.MapType = MapType.Hybrid;
                    break;
                case "Satellite":
                    map.MapType = MapType.Satellite;
                    break;
            }
        }
        public async void GetPositions()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            Task.WaitAll();
           Lattitude = position.Latitude;
            Longitude = position.Longitude;
        }
    }
}
