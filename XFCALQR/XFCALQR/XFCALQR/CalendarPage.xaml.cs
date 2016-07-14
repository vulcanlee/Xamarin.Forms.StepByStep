using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XFCALQR
{
    public partial class CalendarPage : ContentPage
    {
        public DateTime? 選擇日期 { get; set; } = null;
        public CalendarPage()
        {
            InitializeComponent();
        }

        async void OnOKClicked(object sender, EventArgs e)
        {
            if (cal.SelectedDate.HasValue == true)
            {
                選擇日期 = cal.SelectedDate;
                MessagingCenter.Send<選擇日期訊息, DateTime>(new 選擇日期訊息(), "選擇日期", 選擇日期.Value);
            }
            await Navigation.PopModalAsync();

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            選擇日期 = null;
            await Navigation.PopModalAsync();
        }
    }
}
