using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFGestures
{
    public partial class TapInsideFrameXaml : ContentPage
    {
        public TapInsideFrameXaml()
        {
            InitializeComponent();

            // The TapViewModel contains the TapCommand which is wired up in Xaml
            BindingContext = new TapViewModel();
        }
    }
}
