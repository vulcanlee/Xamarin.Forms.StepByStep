using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFCALQR
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<選擇日期訊息, DateTime>(this, "選擇日期", (sender, arg) => {
                labelDate.Text = arg.ToString();
            });
        }

        async void OnbuttonScanClicked(object sender, EventArgs e)
        {
            labelQRCode.Text = "";
            var fooQRCode = await DependencyService.Get<IQrCodeScanningService>().ScanAsync();
            if (string.IsNullOrEmpty(fooQRCode) == false)
            {
                labelQRCode.Text = fooQRCode;
            }
        }

        async void OnbuttonCalendarClicked(object sender, EventArgs e)
        {
            labelDate.Text = "";
            var CalendarPage = new CalendarPage();
            await Navigation.PushModalAsync(CalendarPage);
        }

    }
}
