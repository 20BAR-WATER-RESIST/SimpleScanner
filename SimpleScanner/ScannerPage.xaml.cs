using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System.Threading;

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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource();
            //CancellationTokenSource cancellationTokenSource3 = new CancellationTokenSource();

            SwitchStage("Analyzing", cancellationTokenSource.Token);

            await WaitMethod(3);

            await cancellationTokenSource.CancelAsync();

            await WaitMethod(0.5);

            SwitchStage("Fetching Data", cancellationTokenSource2.Token);

            await WaitMethod(3);

            await cancellationTokenSource.CancelAsync();

        }
    }
    
    private async Task WaitMethod(double seconds)
    {
        await Task.Delay((int)(seconds * 1000));
    }

    private async Task SwitchStage(String stageValue,CancellationToken token)
    {
        StageInfoLabel.Text = stageValue;

        for(int i = 0; i < 4;)
        {
            
            if (i < 3)
            {
                StageInfoLabel.Text += ".";
                i++;

                if (token.IsCancellationRequested)
                {
                    StageInfoLabel.Text = "";
                    i = 4;
                }
                
            }
            else
            {
                StageInfoLabel.Text = stageValue;
                i = 0;

                if (token.IsCancellationRequested)
                {
                    StageInfoLabel.Text = "";
                    i = 4;
                }
            }

            await Task.Delay(600);
        }
    }
}