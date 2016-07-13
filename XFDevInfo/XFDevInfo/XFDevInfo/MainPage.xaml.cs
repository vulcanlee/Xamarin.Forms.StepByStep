using Plugin.Battery;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Plugin.ExternalMaps;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFDevInfo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Init();
        }

        public async void Init()
        {
            #region 電池資訊
            var CrossBattery = Plugin.Battery.CrossBattery.Current;

            label電池狀態1.Text = $"電源來源 : {CrossBattery.PowerSource}";
            label電池狀態2.Text = $"充電狀態 : {CrossBattery.Status}";
            label電池狀態3.Text = $"可用電力 : {CrossBattery.RemainingChargePercent}";
            #endregion

            #region 網路狀態
            var fooCrossConnectivity = CrossConnectivity.Current;

            label網路狀態1.Text = $"是否連上Internet : {fooCrossConnectivity.IsConnected}";
            var fooBandwidths = fooCrossConnectivity.Bandwidths;
            string fooBandwidthsString = "";
            foreach (var item in fooBandwidths)
            {
                fooBandwidthsString += item + " ";
            }
            label網路狀態2.Text = $"可用頻寬 : {fooBandwidthsString}";
            var fooConnectionTypes = fooCrossConnectivity.ConnectionTypes;
            string fooConnectionTypesString = "";
            foreach (var item in fooConnectionTypes)
            {
                fooConnectionTypesString += item + " ";
            }
            label網路狀態3.Text = $"連線類型 : {fooConnectionTypesString}";
            var fooIsReachable = await fooCrossConnectivity.IsRemoteReachable("www.xamarin.com", 80, 2000);
            label網路狀態4.Text = $"可否連上 Xamarin : {fooIsReachable}";
            #endregion

            #region 裝置資訊
            var fooCrossDeviceInfo = CrossDeviceInfo.Current;

            label裝置資訊1.Text = $"此裝置的ID : {fooCrossDeviceInfo.Id}";
            var fooGenerateAppId = fooCrossDeviceInfo.GenerateAppId();
            label裝置資訊6.Text = $"此應用程式的ID : {fooGenerateAppId}";
            label裝置資訊2.Text = $"裝置的型號 : {fooCrossDeviceInfo.Model}";
            label裝置資訊3.Text = $"裝置平台 : {fooCrossDeviceInfo.Platform}";
            label裝置資訊4.Text = $"作業系統版本 : {fooCrossDeviceInfo.Version}";
            label裝置資訊5.Text = $"作業系統版本編號 : {fooCrossDeviceInfo.VersionNumber}";
            #endregion

            #region 位置定位

            #endregion

            #region 觸發震動

            #endregion
        }

        #region 位置定位
        Position position;
        async void Onbutton位置定位(object sender, EventArgs e)
        {
            var fooCrossGeolocator = CrossGeolocator.Current;
            fooCrossGeolocator.DesiredAccuracy = 50;

            position = await fooCrossGeolocator.GetPositionAsync(timeoutMilliseconds: 10000);

            label位置定位1.Text = $"Lat={position.Latitude}, Lon={position.Longitude}";
        }

        void Onbutton開啟地圖(object sender, EventArgs e)
        {
            if (position != null)
            {
                CrossExternalMaps.Current.NavigateTo("現在位置", position.Latitude, position.Longitude);
            }
        }
        #endregion

        #region 觸發震動
        void Onbutton觸發震動(object sender, EventArgs e)
        {
            var fooCrossVibrate = CrossVibrate.Current;
            fooCrossVibrate.Vibration(1000);
        }
        #endregion
    }
}
