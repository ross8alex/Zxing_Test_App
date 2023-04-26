using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScanbotSDK.Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZXing_Test_App.Droid
{
    [Application(LargeHeap = true, Theme = "@style/MainTheme")]
    public class MainApplication : Application
    {
        const string LICENSE_KEY = null; // see the license key notes below! 
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }
        public MainApplication() { }

        public override void OnCreate()
        {
            base.OnCreate();

            var configuration = new SBSDKConfiguration
            {
                EnableLogging = true,
                DetectorType = DocumentDetectorType.MLBased,
            };
            SBSDKInitializer.Initialize(this, LICENSE_KEY, configuration);
        }
    }
}