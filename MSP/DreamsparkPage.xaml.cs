using Windows.UI.Xaml;

namespace MSP
{
    public sealed partial class DreamsparkPage
    {
        public DreamsparkPage()
        {
            this.InitializeComponent();
        }

        private void LayoutAwarePage_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            gridAcces.Height = Window.Current.Bounds.Height - 250;
        }
    }
}
