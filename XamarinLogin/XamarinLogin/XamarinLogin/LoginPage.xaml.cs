using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinLogin
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "回登入頁面");
            buttonLogin.Clicked += ButtonLogin_Clicked;
        }

        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            // 切換到主頁面
            var NextPage = new MainPage();
            
            await Navigation.PushAsync(NextPage);
            ClearStackTo();
        }

        private void ClearStackTo()
        {
            var stack = Navigation.NavigationStack;

            while (stack.Count > 1)
            {
                var page = stack.First();
                if (page != null)
                {
                    Navigation.RemovePage(page);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
