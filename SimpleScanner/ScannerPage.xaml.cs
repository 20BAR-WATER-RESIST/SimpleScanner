using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace SimpleScanner;

public partial class ScannerPage : ContentPage
{
    public ScannerPage()
    {
        InitializeComponent();
        CbEntry.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetImeOptions(ImeFlags.NoAccessoryAction);
        CbEntry.On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetImeOptions(ImeFlags.NoPersonalizedLearning);
        CbEntry.Loaded += CbEntry_Loaded;
        CbEntry.TextChanged += CbEntry_TextChanged;
    }

    private void CbEntry_Loaded(object? sender, EventArgs e)
    {
        CbEntry.Focus();
    }

    private void CbEntry_TextChanged(object? sender, TextChangedEventArgs e)
    {
        
    }
}