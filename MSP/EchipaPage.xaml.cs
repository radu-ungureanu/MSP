using System;
using MSP.Common;
using MSP.Services.Model;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MSP
{
    public sealed partial class EchipaPage
    {
        public EchipaPage()
        {
            this.InitializeComponent();
        }

        private void LayoutAwarePage_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            if (ApplicationView.Value != ApplicationViewState.Snapped)
            {
                gridMembri.Height = gridWannabe.Height = gridAlumnus.Height = Window.Current.Bounds.Height - 260;
            }
        }

        private async void grid_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            var person = e.ClickedItem as Person;

            var message = "Doriți să trimiteți un e-mail către " + person.Email + "?";

            var dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("Da", null, DialogResult.Yes));
            dialog.Commands.Add(new UICommand("Nu", null, DialogResult.No));

            var result = await dialog.ShowAsync();
            if ((DialogResult)result.Id == DialogResult.Yes)
            {
                var mailto = new Uri("mailto:" + person.Email);
                await Windows.System.Launcher.LaunchUriAsync(mailto);
            }
        }
    }
}
