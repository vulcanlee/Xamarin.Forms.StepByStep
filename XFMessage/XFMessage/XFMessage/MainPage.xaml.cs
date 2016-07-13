using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMessage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
            
            // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
            MessagingCenter.Subscribe<MainPage, string>(this, "Hi", (sender, arg) => {
                DisplayAlert("接收到訊息", "參數=" + arg, "OK");
            });

            listView.SetBinding(ListView.ItemsSourceProperty, "Greetings");

        }

        void Onbutton說嗨Click(object sender, EventArgs e)
        {
            MessagingCenter.Send<MainPage>(this, "Hi");
        }

        void Onbutton對約翰說嗨Click(object sender, EventArgs e)
        {
            MessagingCenter.Send<MainPage, string>(this, "Hi", "約翰");
        }

        void Onbutton停止訂閱顯示警告Click(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<MainPage, string>(this, "Hi");
            DisplayAlert("停止訂閱",
                "這個頁面已經停止接收訊息，所以，不再會出現任何警告內容；然而， ViewModel 仍然會繼續接收訊息",
                "OK");
        }
    }
}
