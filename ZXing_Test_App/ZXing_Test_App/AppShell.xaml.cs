using DCVXamarin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZXing_Test_App
{
    public partial class AppShell : Shell, ILicenseVerificationListener
    {
        public static IDCVCameraEnhancer camera;
        public static IDCVBarcodeReader barcodeReader;

        public AppShell(IDCVCameraEnhancer dce, IDCVBarcodeReader dbr)
        {
            InitializeComponent();

            Routing.RegisterRoute("MainPage", typeof(MainPage));

            camera = dce;
            barcodeReader = dbr;

            barcodeReader.InitLicense("DLS2eyJoYW5kc2hha2VDb2RlIjoiMTAxNzkwMjc1LVRYbE5iMkpwYkdWUWNtOXFYMlJpY2ciLCJtYWluU2VydmVyVVJMIjoiaHR0cHM6Ly9tbHRzLmR5bmFtc29mdC5jb20iLCJvcmdhbml6YXRpb25JRCI6IjEwMTc5MDI3NSIsImNoZWNrQ29kZSI6NTMwNDgzMTYzfQ==", this);
        }

        public void LicenseVerificationCallback(bool isSuccess, string msg)
        {
            if (!isSuccess)
            {
                System.Console.WriteLine(msg);
            }
        }
    }
}