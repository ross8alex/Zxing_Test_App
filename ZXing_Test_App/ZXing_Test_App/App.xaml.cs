using DCVXamarin;
using ScanbotSDK.Xamarin.Forms;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZXing_Test_App
{
    public partial class App : Application, ILicenseVerificationListener
    {
        public static IDCVCameraEnhancer camera;
        public static IDCVBarcodeReader barcodeReader;

        public App(IDCVCameraEnhancer dce, IDCVBarcodeReader dbr)
        {
            InitializeComponent();

            //Dynamsoft init
            camera = dce;
            barcodeReader = dbr;

            barcodeReader.InitLicense("DLS2eyJoYW5kc2hha2VDb2RlIjoiMTAxNzkwMjc1LVRYbE5iMkpwYkdWUWNtOXFYMlJpY2ciLCJtYWluU2VydmVyVVJMIjoiaHR0cHM6Ly9tbHRzLmR5bmFtc29mdC5jb20iLCJvcmdhbml6YXRpb25JRCI6IjEwMTc5MDI3NSIsImNoZWNrQ29kZSI6NTMwNDgzMTYzfQ==", this);

            //App shell configuration causes issues on iOS and Android
            //iOS: on loading the scanner page, the initial load is fine but subsequent times the page is loaded, it takes around 10 seconds to load
            //Android: on loading the scanner page, the camera view doesn't populate with the camera, although the scanner is functional
            MainPage = new AppShell(dce, dbr);

            //Normal navigation page configuration resolves both the above issues
            //MainPage = new NavigationPage(new MainPage());
        }

        public void LicenseVerificationCallback(bool isSuccess, string msg)
        {
            if (!isSuccess)
            {
                System.Console.WriteLine(msg);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
