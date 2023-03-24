using ZXing.Net.Maui;

namespace BarcodeScanner;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		barcodeRead.Options = new ZXing.Net.Maui.BarcodeReaderOptions()
		{
            /*if holding phone upside down it will try to rotate it and get the value*/
            //AutoRotate= true

            /*which format it should scan*/
            //Formats = {}

            /*detect all barcodes*/
            //Formats=BarcodeFormats.OneDimensional

            /*tries harder to detect the barcodes,chech documentation*/
            //TryHarder= true	
        };
	}

	private void CameraBarcode_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		//barcode scanning is happening on a background thread so the ui needs to be updated in the main thread
		//Dispatcher helps to dispatch and go to the main thread so it doesn't crash
		Dispatcher.Dispatch (() =>
		{
			/*Results[0] is a collection
            inspect from one barcode(result) the value,raw data*/
			//Result.Text = e.Results[0].Value;

			//Included to see the format of the QR
			Result.Text = $"{e.Results[0].Value} {e.Results[0].Format}";
        });

	}


}

