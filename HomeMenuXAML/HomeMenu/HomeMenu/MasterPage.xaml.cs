using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HomeMenu
{
    public partial class MasterPage : ContentPage
    {
        public ListView MyListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "XF 控制項1",
                Icon = "\uf00b",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "XF 控制項2",
                Icon = "\uf044",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Grid版面配置",
                Icon = "\uf085",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "堆疊與捲動版面配置",
                Icon = "\uf009",
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
