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
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource();

            _ = SwitchStage("Analyzing", cancellationTokenSource.Token);

            await WaitMethod(3);

            await cancellationTokenSource.CancelAsync();

            StageInfoLabel.Text = "";

            _ = SwitchStage("Fetching Data", cancellationTokenSource2.Token);

            await WaitMethod(3);

            await cancellationTokenSource2.CancelAsync();

            StageInfoLabel.Text = "";

        }
    }
    
    private async Task WaitMethod(double seconds)
    {
        await Task.Delay((int)(seconds * 1000));
    }

    private async Task SwitchStage(string stageValue,CancellationToken token)
    {
        StageInfoLabel.Text = stageValue;

        for (int i = 0; i < 4;)
        {
            //if (token.IsCancellationRequested)
            //{
            //    StageInfoLabel.Text = "";
            //}

            if (StageInfoLabel.Text != "")
            {
                if (i < 3)
                {
                    StageInfoLabel.Text += ".";
                    i++;
                }
                else
                {
                    StageInfoLabel.Text = stageValue;
                    i = 0;
                }

                await Task.Delay(600, token);
            }
            else
            {
                i = 4;
            }
        }
    }
}