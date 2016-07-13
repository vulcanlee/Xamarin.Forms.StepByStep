using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFDevice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        void OnGuessClicked(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Device.OnPlatform(
                iOS: ()=>
                {
                    sb.Append("嗯嗯嗯，您是 iOS, ");
                },
                Android: () =>
                {
                    sb.Append("嗯嗯嗯，您是 Android, ");
                },
                WinPhone: () =>
                {
                    sb.Append("嗯嗯嗯，您是 WinPhone, ");
                }
                );
            sb.Append(Device.Idiom.ToString());

            button猜猜我是誰.Text = sb.ToString();
        }

        void OnTimerClicked(object sender, EventArgs e)
        {
            int fooCC = 0;
            int fooMax = 50;
            Device.StartTimer(new TimeSpan(0, 0, 1), () => {

                button定時更新.Text = $"{DateTime.Now}";

                if (++fooCC > fooMax)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });
        }

        void OnBackgroundClicked(object sender, EventArgs e)
        {
            Task.Factory.StartNew(()=>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    label處理中.Text = $"處理中 現在時間:{DateTime.Now}";
                });
            }); 
        }

        void OnOpenUriClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.xamarin.com"));
        }
    }
}
