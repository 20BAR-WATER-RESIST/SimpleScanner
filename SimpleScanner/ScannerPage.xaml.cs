using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace SimpleScanner;

public partial class ScannerPage : ContentPage
{
    private int TextInsertedCounter { get; set; } = 0;
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

    private async void CbEntry_TextChanged(object? sender, TextChangedEventArgs e)
    {
        TextInsertedCounter++;
        
        if (TextInsertedCounter == 1)
        {
            //await AnalyzingStage();
            await WaitMethod(3);
        }
    }
    
    private async Task WaitMethod(int seconds)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        await AnalyzingStage(cancellationToken);
        
        await Task.Delay(seconds * 1000);
        cancellationTokenSource.Cancel();
        
        return;
    }

    private async Task AnalyzingStage(CancellationToken token)
    {
        StageInfoLabel.Text = "Analyzing";

        for(int i = 0; i < 4;)
        {
            await Task.Delay(600);
            if (i < 3)
            {
                StageInfoLabel.Text += ".";
                i++;
            }
            else
            {
                StageInfoLabel.Text = "Analyzing";
                i = 0;
            }
        }
        return;
    }
}