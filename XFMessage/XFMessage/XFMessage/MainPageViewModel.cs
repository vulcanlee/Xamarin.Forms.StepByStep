using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMessage
{
    public class MainPageViewModel
    {
        public ObservableCollection<string> Greetings { get; set; }

        public MainPageViewModel()
        {
            Greetings = new ObservableCollection<string>();

            MessagingCenter.Subscribe<MainPage>(this, "Hi", (sender) => {
                Greetings.Add("Hi");
            });

            MessagingCenter.Subscribe<MainPage, string>(this, "Hi", (sender, arg) => {
                Greetings.Add("Hi " + arg);
            });
        }
    }
}
