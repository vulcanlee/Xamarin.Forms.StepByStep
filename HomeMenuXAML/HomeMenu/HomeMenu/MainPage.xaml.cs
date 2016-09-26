using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HomeMenu
{
    public partial class MainPage : MasterDetailPage
    {
        MasterPage fooMasterPage = new MasterPage();
        NavigationPage fooNavigationPage = new NavigationPage();

        public MainPage()
        {
            InitializeComponent();

            //this.Master = fooMasterPage;
            //this.Detail = new NavigationPage(new DetailView1());

            fooMasterPage = this.Master as MasterPage;
            fooNavigationPage = this.Detail as NavigationPage;
            masterPage.MyListView.ItemSelected += OnItemSelected;

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if (item.Title == "XF 控制項1")
                {
                    Detail = new NavigationPage(new DetailView1());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "XF 控制項2")
                {
                    Detail = new NavigationPage(new DetailView2());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "Grid版面配置")
                {
                    Detail = new NavigationPage(new DetailView3());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "堆疊與捲動版面配置")
                {
                    Detail = new NavigationPage(new DetailView4());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }
    }
}
