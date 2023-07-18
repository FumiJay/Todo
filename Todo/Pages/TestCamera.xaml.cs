using Camera.MAUI;
using Capture.Vision.Maui;
using Dynamsoft;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using static Dynamsoft.BarcodeQRCodeReader;

namespace Todo.Pages;

public partial class TestCamera : ContentPage
{
    //https://www.youtube.com/watch?v=FuvFrIS9wm0
    public TestCamera()
    {
        InitializeComponent();

        this.Appearing += OnAppearing;
        this.Disappearing += OnDisappearing;

        //cameraView.BarCodeOptions = new()
        //{
        //    AutoRotate = true,
        //    PossibleFormats = { ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.CODE_39 }
        //};
    }

    private void OnAppearing(object sender, EventArgs e)
    {
        //cameraView.IsEnabled = true;
        cameraView.BarCodeDetectionEnabled = true;
    }

    private void OnDisappearing(object sender, EventArgs e)
    {
        //cameraView.IsEnabled = false;
        cameraView.BarCodeDetectionEnabled = false;
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.FirstOrDefault();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            this.barcodeResult.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";

            await Navigation.PushAsync(new AllNotesPage());
        });
    }
}



