using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XFMap
{
    public class GeocoderPage : ContentPage 
    {
        Geocoder geoCoder;
        Label l = new Label();

        public GeocoderPage()
        {
            geoCoder = new Geocoder();

            var b1 = new Button { Text = "反定位 '25.0436439, 121.525664'" };
            b1.Clicked += async (sender, e) => {
                var fortMasonPosition = new Position(25.0436439, 121.525664);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(fortMasonPosition);
                foreach (var a in possibleAddresses)
                {
                    l.Text += a + "\n";
                }
            };

            var b2 = new Button { Text = "定位 '多奇數位創意有限公司'" };
            b2.Clicked += async (sender, e) => {
                var xamarinAddress = "多奇數位創意有限公司";
                var approximateLocation = await geoCoder.GetPositionsForAddressAsync(xamarinAddress);
                foreach (var p in approximateLocation)
                {
                    l.Text += p.Latitude + ", " + p.Longitude + "\n";
                }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    b2,
                    b1,
                    l
                }
            };
        }
    }
}
