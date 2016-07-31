using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFSQLite
{
    public partial class MainPage : ContentPage
    {
        DoggyDatabase fooDoggyDatabase;
        public MainPage()
        {
            InitializeComponent();

            fooDoggyDatabase = new DoggyDatabase();

            labelMessagePath.Text = $"路徑: {fooDoggyDatabase.DBPath}";

            button寫入資料庫.Clicked += (s, e) =>
            {
                fooDoggyDatabase.DeleteAll();
                fooDoggyDatabase.SaveItem(new MyRecord
                {
                    UserName = "Vulcan Lee",
                    SelectItem = "一顆蘋果",
                    Done = false,
                });
                labelMessageWrite.Text = $"資料已經寫入資料表內";
            };
            button從資料庫讀出.Clicked += (s, e) =>
            {
                var fooItem = fooDoggyDatabase.GetItems().FirstOrDefault();

                labelMessageRead.Text = $"從資料表內讀取: {fooItem.UserName} / {fooItem.SelectItem}";
            };
        }
    }
}
