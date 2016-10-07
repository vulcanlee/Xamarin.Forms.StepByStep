using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFWebSrv
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnRESTfulClicked(object sender, EventArgs e)
        {
            //var fooURL = $"http://doggyrestfulapi.azurewebsites.net/api/SumData?value1={entryValue1.Text}&value2={entryValue2.Text}";
            var fooURL = $"http://xamarindoggy.azurewebsites.net/api/SumData?value1={entryValue1.Text}&value2={entryValue2.Text}";
            var fooClient = new HttpClient();
            var fooResult = await fooClient.GetStringAsync(fooURL);
            labelRESTful.Text = $"透過 RESTful API 計算出的結果 : {fooResult}";
        }

        async void OnWCFClicked(object sender, EventArgs e)
        {
            int v1 = int.Parse(entryValue1.Text);
            int v2 = int.Parse(entryValue2.Text);
            int v3 = await DependencyService.Get<IWCFService>().Sum(v1, v2);
            labelWCF.Text = $"透過 WCF 計算出的結果 : {v3}"; ;
        }
    }
}
