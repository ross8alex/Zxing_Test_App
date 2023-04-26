using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using DCVXamarin.Droid;
using Xamarin.Essentials;
using ScanbotSDK.Xamarin.Forms;

namespace ZXing_Test_App.Droid
{
    [Activity(Label = "ZXing_Test_App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string LICENSE_KEY = null;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            DCVCameraEnhancer dce = new DCVCameraEnhancer(context: this);
            DCVBarcodeReader dbr = new DCVBarcodeReader();

            LoadApplication(new App(dce, dbr));

            Permissions.RequestAsync<Permissions.Camera>();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}