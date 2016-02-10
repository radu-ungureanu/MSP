using System;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace MSP.Common
{
    public class BaseSendMailButton : Button
    {
        private string _url;

        public BaseSendMailButton(string url)
        {
            _url = url;
            DefaultStyleKey = GetType();
            Tapped += BaseSendMailButton_Tapped;
        }

        async void BaseSendMailButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            var dialog = new MessageDialog("Doriți să trimiteți un e-mail către " + _url + "?");
            dialog.Commands.Add(new UICommand("Da", null, DialogResult.Yes));
            dialog.Commands.Add(new UICommand("Nu", null, DialogResult.No));

            var result = await dialog.ShowAsync();
            if ((DialogResult)result.Id == DialogResult.Yes)
            {
                await Launcher.LaunchUriAsync(new Uri("mailto:" + _url));
            }
        }
    }
}
