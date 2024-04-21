using SimpleScanner.CustomControls;

namespace SimpleScanner;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new ScannerPage();
        
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {
            if( view is CustomBarcodeEntry)
            {
#if ANDROID
                    handler.PlatformView.ShowSoftInputOnFocus = false;
#endif
            }
        });
    }
}