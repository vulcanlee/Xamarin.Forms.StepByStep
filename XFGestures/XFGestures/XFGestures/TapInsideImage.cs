using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFGestures
{
    public class TapInsideImage : ContentPage
    {
        int tapCount;
        readonly Label label;

        public TapInsideImage()
        {
            var image = new Image
            {
                Source = "tapped.jpg",

                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            var foo = new StackLayout();
            

            var tapGestureRecognizer = new TapGestureRecognizer();
            //			tapGestureRecognizer.NumberOfTapsRequired = 2; // double-tap
            tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
            image.GestureRecognizers.Add(tapGestureRecognizer);


            label = new Label
            {
                Text = "點擊圖片!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            label.GestureRecognizers.Add(tapGestureRecognizer);

            Content = new StackLayout
            {
                Padding = new Thickness(20, 100),

                Children =
                {
                    image,
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

            var imageSender = (Image)sender;

            // watch the monkey go from color to black&white!
            if (tapCount % 2 == 0)
            {
                imageSender.Source = "tapped.jpg";
            }
            else
            {
                imageSender.Source = "tapped_bw.jpg";
            }
            Debug.WriteLine("image tapped: " + ((FileImageSource)imageSender.Source).File);
        }
    }
}
