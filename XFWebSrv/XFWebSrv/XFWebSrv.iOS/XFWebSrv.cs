using System;
using System.Collections.Generic;
using System.Text;
using XFWCFPCL;
using XFWebSrv.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(WCFService))]
namespace XFWebSrv.iOS
{
    public class WCFService : WCFServiceBase, IWCFService
    {
    }
}
