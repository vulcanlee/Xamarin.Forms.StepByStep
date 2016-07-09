using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFMap
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new XFMap.MainPage();

            var tabs = new TabbedPage();

            // demonstrates the map control with zooming and map-types
            tabs.Children.Add(new MapPage { Title = "地圖縮放", Icon = "glyphish_74_location.png" });

            // demonstrates the map control with zooming and map-types
            tabs.Children.Add(new PinPage { Title = "位置標示", Icon = "glyphish_07_map_marker.png" });

            // demonstrates the Geocoder class
            tabs.Children.Add(new GeocoderPage { Title = "定位反查", Icon = "glyphish_13_target.png" });

            // opens the platform's native Map app
            tabs.Children.Add(new MapAppPage { Title = "外部地圖", Icon = "glyphish_103_map.png" });

            MainPage = tabs;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
