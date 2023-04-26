using DCVXamarin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace ZXing_Test_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamsoftScannerPage : ContentPage, IBarcodeResultListener
    {
        public DynamsoftScannerPage()
        {
            InitializeComponent();

            App.barcodeReader.SetCameraEnhancer(App.camera);
            App.barcodeReader.AddResultListener(this);
        }

        public void BarcodeResultCallback(int frameID, BarcodeResult[] barcodeResults)
        {
            // Here is an example code on how to display the barcode results on the view.
            string newBarcodeText = "";
            // The parameter 'barcodeResults' is an Array of BarcodeResult object.
            // Parse the 'barcodeResults' when it is not null.
            if (barcodeResults != null && barcodeResults.Length > 0)
            {
                for (int i = 0; i < barcodeResults.Length; i++)
                {
                    {
                        //The BarcodeText property of BarcodeResult is the string of barcode text result.
                        newBarcodeText += barcodeResults[i].BarcodeText;
                        newBarcodeText += "; ";
                    }
                }
                // On UI thread, refresh the previously prepared label with new barcode results.
                Device.BeginInvokeOnMainThread(() => {
                    barcodeResultLabel.Text = newBarcodeText;
                });
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Start barcode decoding thread when the view appears.
            App.barcodeReader.StartScanning();
            // Open the camera the the view appears.
            App.camera.Open();

            //This is a workaround that functions on android to fix the issue caused by the shell. It isn't necessary when using a navigationpage instead
            if (Device.RuntimePlatform == Device.Android)
            {
                await Task.Delay(500);

                OnDisappearing();

                base.OnAppearing();

                // Start barcode decoding thread when the view appears.
                App.barcodeReader.StartScanning();
                // Open the camera the the view appears.
                App.camera.Open();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Stop barcode decoding thread when the view appears.
            App.barcodeReader.StopScanning();
            // Close the camera the the view appears.
            App.camera.Close();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Manual load button is another workaround for the android shell issue, if you remove the other workaround this will show the camera not loading, but clicking this button will load the camera
            OnDisappearing();
            OnAppearing();
        }
    }
}