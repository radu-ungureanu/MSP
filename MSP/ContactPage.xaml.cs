using Bing.Maps;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace MSP
{
    public sealed partial class ContactPage
    {
        DataTransferManager dtm;

        public ContactPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dtm = DataTransferManager.GetForCurrentView();
            dtm.DataRequested += dtm_DataRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            dtm.DataRequested -= dtm_DataRequested;
        }

        void dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string contact = "Ne puteți găsi în sala EG101, sau la adresa de email: msproupb@studentpartner.com"; 

            DataPackage data = args.Request.Data;
            data.Properties.Title = "Microsoft Student Partner UPB";
            data.SetText(contact);
        }

        private void LayoutAwarePage_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            map.Height = map.Width = Window.Current.Bounds.Height - 280;
        }

        private void map_Loaded_1(object sender, RoutedEventArgs e)
        {
            var location = new Location(44.436367, 26.047787);
            MapLayer.SetPosition(pushPin, location);
        }

        private void map_Loaded_2(object sender, RoutedEventArgs e)
        {
            var location = new Location(44.436367, 26.047787);
            MapLayer.SetPosition(pushPin2, location);
        }
    }
}
