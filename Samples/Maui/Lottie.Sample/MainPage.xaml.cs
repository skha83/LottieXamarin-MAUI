using Microsoft.Maui.ApplicationModel;

namespace Lottie.Sample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            
            //Task.Run(async () => 
            //{
            //    while (true)
            //    {
            //        await MainThread.InvokeOnMainThreadAsync(() =>
            //        {
            //            this.A1.enab
            //            var old = this.A1.Progress;
            //            this.A1.Progress = 0;
            //            this.A1.Progress = old;
            //        });

            //        await Task.Delay(10);
            //    }
            //});            
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
