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

            #region 這個區段，說明如何使用手勢操作的程式碼寫法與定義
            var tabs = new TabbedPage();

            // 點擊圖片，從彩色變灰色，這部分都使用 C# 的程式碼來定義手勢操作要做的動作
            tabs.Children.Add(new TapInsideImage { Title = "圖片手勢", Icon = "csharp.png" });

            // 點擊框架 Frame，使用 C# 的程式碼來定義手勢操作要做的動作
            tabs.Children.Add(new TapInsideFrame { Title = "框架手勢", Icon = "csharp.png" });

            // 使用XAML來定義單擊、雙擊的宣告方式與檢視模型的命令處理邏輯
            tabs.Children.Add(new TapInsideFrameXaml { Title = "Xaml手勢", Icon = "xaml.png" });

            MainPage = tabs;
            #endregion
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
