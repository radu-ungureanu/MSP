using System;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace MSP.Common
{
    public class BaseGoToButton : Button
    {
        private string HTTP = "http://";
        private string HTTPS = "https://";
        private string _url;
        private string _askUrl;

        public BaseGoToButton(string url)
        {
            _url = url;

            if (_url.StartsWith(HTTP))
            {
                _askUrl = url.Substring(HTTP.Length);
            }
            else if (_url.StartsWith(HTTPS))
            {
                _askUrl = url.Substring(HTTPS.Length);
            }

            DefaultStyleKey = GetType();
            Tapped += BaseGoToButton_Tapped;
        }

        async void BaseGoToButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var message = "Doriți să fiți redirecționat către " + _askUrl + "?";
             
            var dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("Da", null, DialogResult.Yes));
            dialog.Commands.Add(new UICommand("Nu", null, DialogResult.No));

            var result = await dialog.ShowAsync();
            if ((DialogResult)result.Id == DialogResult.Yes)
            {
                await Launcher.LaunchUriAsync(new Uri(_url));
            }
        }
    }
}
