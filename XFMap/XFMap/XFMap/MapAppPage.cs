using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XFMap
{
    public class MapAppPage : ContentPage
    {
        // WARNING: when adding latitude/longitude values be careful of localization.
        // European (and other countries) use a comma as the separator, which will break the request

        public MapAppPage()
        {
            var l = new Label
            {
                Text = "底下兩個按鈕按下之後，將會離開當前的應用程式，並且打開原生系統內建的地圖應用程式"
            };

            var openLocation = new Button
            {
                Text = "使用原生系統內建地圖程式，顯示指定座標"
            };
            openLocation.Clicked += (sender, e) => {

                if (Device.OS == TargetPlatform.iOS)
                {
                    //https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    Device.OpenUri(new Uri("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA"));
                }
                else if (Device.OS == TargetPlatform.Android)
                {
                    // opens the Maps app directly
                    Device.OpenUri(new Uri("geo:0,0?q=394+Pacific+Ave+San+Francisco+CA"));

                }
                else if (Device.OS == TargetPlatform.Windows)
                {
                    Device.OpenUri(new Uri("bingmaps:?where=394 Pacific Ave San Francisco CA"));
                }
            };

            var openDirections = new Button
            {
                Text = "使用原生系統內建地圖程式，提供導航資訊"
            };
            openDirections.Clicked += (sender, e) => {

                if (Device.OS == TargetPlatform.iOS)
                {
                    //https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    Device.OpenUri(new Uri("http://maps.apple.com/?daddr=San+Francisco,+CA&saddr=cupertino"));

                }
                else if (Device.OS == TargetPlatform.Android)
                {
                    // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                    Device.OpenUri(new Uri("http://maps.google.com/?daddr=San+Francisco,+CA&saddr=Mountain+View"));

                }
                else if (Device.OS == TargetPlatform.Windows)
                {
                    Device.OpenUri(new Uri("bingmaps:?rtp=adr.394 Pacific Ave San Francisco CA~adr.One Microsoft Way Redmond WA 98052"));
                }
            };
            Content = new StackLayout
            {
                Padding = new Thickness(5, 20, 5, 0),
                HorizontalOptions = LayoutOptions.Fill,
                Children = {
                    l,
                    openLocation,
                    openDirections
                }
            };
        }
    }
}
