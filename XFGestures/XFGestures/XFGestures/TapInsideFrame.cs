using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFGestures
{
    public class TapInsideFrame : ContentPage
    {
        int tapCount;
        readonly Label label;

        public TapInsideFrame()
        {
            var frame = new Frame
            {
                OutlineColor = Color.Accent,
                BackgroundColor = Color.Transparent,
                Padding = new Thickness(20, 100),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Content = new Label
                {
                    Text = "點擊(Tap) 框架內部",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                }
            };


            var tapGestureRecognizer =
                new TapGestureRecognizer();
            //tapGestureRecognizer.NumberOfTapsRequired = 2; // double-tap
            tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
            frame.GestureRecognizers.Add(tapGestureRecognizer);


            label = new Label
            {
                Text = " ",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout
            {
                Children =
                {
                    frame,
                    label
                }
            };
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            tapCount++;
            label.Text = String.Format("已經觸發 {0} 次點擊(Tap)!",
                tapCount,
                tapCount == 1 ? "" : "s");
        }
    }
}
