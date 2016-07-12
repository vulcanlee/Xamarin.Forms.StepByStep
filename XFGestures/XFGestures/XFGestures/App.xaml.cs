using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XFGestures
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new XFGestures.MainPage();

            var tabs = new TabbedPage();

            // demonstrates an Image tap (and changing the image)
            tabs.Children.Add(new TapInsideImage { Title = "圖片手勢", Icon = "csharp.png" });

            // demonstrates adding GestureRecognizer to a Frame
            tabs.Children.Add(new TapInsideFrame { Title = "框架手勢", Icon = "csharp.png" });

            // demonstrates using Xaml, Command and databinding
            tabs.Children.Add(new TapInsideFrameXaml { Title = "Xaml手勢", Icon = "xaml.png" });

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
