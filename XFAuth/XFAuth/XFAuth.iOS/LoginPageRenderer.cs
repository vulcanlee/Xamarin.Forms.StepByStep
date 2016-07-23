using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFAuth;
using XFAuth.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace XFAuth.iOS
{
    public class LoginPageRenderer : PageRenderer
    {
        LoginPage page;
        bool loginInProgress;

        public LoginPageRenderer()
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null ||
                Element == null)
                return;

            page = e.NewElement as LoginPage;
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (page == null ||
                loginInProgress)
                return;

            loginInProgress = true;
            try
            {
                OAuth2Authenticator auth = new OAuth2Authenticator(
                    page.ProviderOAuthSettings.ClientId, // your OAuth2 client id
                    page.ProviderOAuthSettings.ClientSecret, // your OAuth2 client secret
                    page.ProviderOAuthSettings.ScopesString, // scopes
                    new Uri(page.ProviderOAuthSettings.AuthorizeUrl), // the scopes, delimited by the "+" symbol
                    new Uri(page.ProviderOAuthSettings.RedirectUrl), // the redirect URL for the service
                    new Uri(page.ProviderOAuthSettings.AccessTokenUrl));

                auth.AllowCancel = true;
                // If authorization succeeds or is canceled, .Completed will be fired.
                auth.Completed += async (sender, args) => {
                    if (args.IsAuthenticated)
                    {
                        var token = args.Account.Properties["access_token"];
                        MessagingCenter.Send<OAuthMessage, string>(new OAuthMessage(), "Authenticated", token);
                    }
                    else
                    {
                        MessagingCenter.Send<OAuthMessage, string>(new OAuthMessage(), "Authenticated", "Canceled!");
                    }
                    await DismissViewControllerAsync(true);
                    await page.Navigation.PopModalAsync();
                    loginInProgress = false;
                };

                auth.Error += (sender, args) =>
                {
                    Console.WriteLine("Error: {0}", args.Exception);
                };

                await PresentViewControllerAsync(auth.GetUI(), true);

            }
            catch (Exception ex)
            {
                MessagingCenter.Send<OAuthMessage, string>(new OAuthMessage(), "Authenticated", $"Authentication Exception: {ex.Message}");
            }
        }
    }
}
