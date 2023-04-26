using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZXing.Mobile;
using ZXing;
using ZXing.Net.Mobile.Forms;
using System.Threading.Tasks;

namespace ZXing_Test_App
{
    public class ScannerPage : ContentPage
    {
        private ZXingScannerView zxing;

        public ScannerPage()
        {
            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingScannerView",
                Options = new MobileBarcodeScanningOptions()
                {
                    TryHarder = false,
                    PureBarcode = false,
                    CameraResolutionSelector = HandleCameraResolutionSelectorDelegate,
                    PossibleFormats = new List<BarcodeFormat>() { BarcodeFormat.CODE_128, BarcodeFormat.CODE_39 }
                }
            };

            zxing.OnScanResult += (result) => Device.BeginInvokeOnMainThread(async () =>
            {
                // Stop analysis until we navigate away so we don't keep reading barcodes
                //zxing.IsAnalyzing = false;

                await ScanResultAsync(result);
            });

            ZXingDefaultOverlay overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = false,
                AutomationId = "zxingDefaultOverlay"
            };

            Grid ScannerGrid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            ScannerGrid.Children.Add(zxing);
            ScannerGrid.Children.Add(overlay);
            Content = ScannerGrid;
        }

        CameraResolution HandleCameraResolutionSelectorDelegate(List<CameraResolution> availableResolutions)
        {
            //Don't know if this will ever be null or empty
            if (availableResolutions == null || availableResolutions.Count < 1)
            {
                return new CameraResolution() { Width = 800, Height = 600 };
            }

            //Debugging revealed that the last element in the list expresses the highest resolution for ios.
            //while the first element in the list express the highest resolution for android
            if (Device.RuntimePlatform == Device.iOS)
            {
                return availableResolutions[availableResolutions.Count - 1];
            }

            return availableResolutions[0];
        }

        public async Task ScanResultAsync(ZXing.Result result)
        {
            if (result != null && !string.IsNullOrEmpty(result.Text))
            {
                await DisplayAlert("Barcode Scanned", $"Barcode: {result.Text} Scanned", "Ok");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
            zxing.IsEnabled = true;
        }
    }
}