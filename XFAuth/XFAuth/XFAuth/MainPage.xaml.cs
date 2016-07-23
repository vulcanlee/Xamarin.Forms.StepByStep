using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            button登入Facebook.Clicked += async (s, e) =>
             {
                 await Navigation.PushModalAsync(new LoginPage(Provider.Facebook));
             };

            MessagingCenter.Subscribe<OAuthMessage, string>(this, "Authenticated", (sender, e) =>
            {
                var foo = new Button();
                button登入Facebook.IsVisible = false;

                labelToken.IsVisible = true;

                var fooResult = e as string;
                if (fooResult == "Canceled!" )
                {
                    labelToken.Text = "使用者中斷";
                    labelTokenError.Text = "使用者取消登入Facebook";
                    labelTokenError.IsVisible = true;
                    labelTokenValue.IsVisible = false;
                }
                else if (fooResult.Contains("Authentication Exception"))
                {
                    labelToken.Text = "Exception";
                    labelTokenError.Text = fooResult;
                    labelTokenError.IsVisible = true;
                    labelTokenValue.IsVisible = false;
                }
                else
                {
                    labelToken.Text = "Token";
                    labelTokenValue.Text = fooResult;
                    labelTokenValue.IsVisible = true;
                    labelTokenError.IsVisible = true;
                }
            });

        }
    }
}
