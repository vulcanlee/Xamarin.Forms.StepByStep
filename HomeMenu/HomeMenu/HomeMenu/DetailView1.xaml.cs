using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HomeMenu
{
    public partial class DetailView1 : ContentPage
    {
        public DetailView1()
        {
            InitializeComponent();

            #region 按鈕初始化
            button我的按鈕.Clicked += (s, e) =>
            {
                DisplayAlert("通知", "您已經按下了按鈕", "確定");
            };
            #endregion

            #region 多行文字輸入盒初始化
            editor多行文字輸入盒.Text = "這個控制項，\r\n可以輸入多行資料\r\n每行輸入後\r\n按下Enter\r\n就會自動換行";
            #endregion

        }
    }
}
