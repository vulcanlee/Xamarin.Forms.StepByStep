using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFWCFPCL;
using XFWebSrv.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(WCFService))]
namespace XFWebSrv.Droid
{
    public class WCFService : WCFServiceBase, IWCFService
    {
    }
}