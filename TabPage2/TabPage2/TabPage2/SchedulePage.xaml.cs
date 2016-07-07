using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabPage2
{
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
        }

        async void OnUpcomingAppointmentsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpcomingAppointmentsPage());
        }
    }
}
