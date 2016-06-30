using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HomeMenu
{
    public partial class DetailView2 : ContentPage
    {
        public DetailView2()
        {
            InitializeComponent();

            #region 資料清單選擇器
            picker我的選單.Items.Add("清單項目01");
            picker我的選單.Items.Add("清單項目02");
            picker我的選單.Items.Add("清單項目03");
            picker我的選單.Items.Add("清單項目04");
            picker我的選單.Items.Add("清單項目05");
            #endregion
        }
    }
}
