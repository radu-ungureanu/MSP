using System;
using MSP.MSPDataServices;
using MSP.Services.Model;
using MSP.ViewModel;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace MSP
{
    public sealed partial class MainPage
    {
        MainViewModel vm;
        DataTransferManager dtm;

        public MainPage()
        {
            this.InitializeComponent();
            vm = (MainViewModel)DataContext;
            vm._propertyChanged += BlogEntryChanged;
        }

        void BlogEntryChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Entries")
            {
                if (vm.Entries.Count > 0)
                {
                    //Create the Large Tile
                    var largeTile = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideText04);
                    largeTile.GetElementsByTagName("text")[0].InnerText = vm.Entries[0].Title;

                    //Create a Small Tile
                    var smallTile = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquareText04);
                    smallTile.GetElementsByTagName("text")[0].InnerText = vm.Entries[0].Title;

                    //Merge the two updates into one <visual> XML node
                    var newNode = largeTile.ImportNode(smallTile.GetElementsByTagName("binding").Item(0), true);
                    largeTile.GetElementsByTagName("visual").Item(0).AppendChild(newNode);

                    TileNotification notification = new TileNotification(largeTile);                 
                    TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Select day to show in timetable
            //switch (DateTime.Now.DayOfWeek)
            //{
            //    case DayOfWeek.Monday: orarLuni.Width = 200; orarLuni.BorderThickness = new Thickness(1); break;
            //    case DayOfWeek.Tuesday: orarMarti.Width = 200; orarMarti.BorderThickness = new Thickness(1); break;
            //    case DayOfWeek.Wednesday: orarMiercuri.Width = 200; orarMiercuri.BorderThickness = new Thickness(1); break;
            //    case DayOfWeek.Thursday: orarJoi.Width = 200; orarJoi.BorderThickness = new Thickness(1); break;
            //    case DayOfWeek.Friday: orarVineri.Width = 200; orarVineri.BorderThickness = new Thickness(1); break;
            //    case DayOfWeek.Saturday: orarSambata.Width = 200; orarSambata.BorderThickness = new Thickness(1); break;
            //    case DayOfWeek.Sunday: orarDuminica.Width = 200; orarDuminica.BorderThickness = new Thickness(1); break;
            //}

            //Share contract
            dtm = DataTransferManager.GetForCurrentView();
            dtm.DataRequested += dtm_DataRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            dtm.DataRequested -= dtm_DataRequested;
        }

        //Share information
        void dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string title = "Microsoft Student Partners UPB";
            Uri uri = new Uri("http://www.microsoft.pub.ro");

            DataPackage data = args.Request.Data;
            data.Properties.Title = title;
            data.SetUri(uri);
        }

        private void LayoutAwarePage_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            if (ApplicationView.Value == ApplicationViewState.Snapped)
            {
                snappedView.Height = Window.Current.Bounds.Height - 140;
            }
            //else
            //{
            //    gridPeople.Height = Window.Current.Bounds.Height - 420;
            //    gridBlog.Height = Window.Current.Bounds.Height - 280;
            //    orar.Height = Window.Current.Bounds.Height - 280;
            //    orarLuni.Height = Window.Current.Bounds.Height - 280;
            //    orarMarti.Height = Window.Current.Bounds.Height - 280;
            //    orarMiercuri.Height = Window.Current.Bounds.Height - 280;
            //    orarJoi.Height = Window.Current.Bounds.Height - 280;
            //    orarVineri.Height = Window.Current.Bounds.Height - 280;
            //    orarSambata.Height = Window.Current.Bounds.Height - 280;
            //    orarDuminica.Height = Window.Current.Bounds.Height - 280;
            //}           
        }

        private void BlogTapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(BlogSummaryPage));
        }

        private void OrarTapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrarPage));
        }

        private void DreamsparkTapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DreamsparkPage));
        }

        private void ImaginecupTapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ImagineCupPage));
        }

        private void EchipaTapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(EchipaPage));
        }

        private void ContactTapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ContactPage));
        }

        private async void gridBlog_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            progressBar.IsIndeterminate = true;
            progressBar.Visibility = Visibility.Visible;

            var item = e.ClickedItem as BlogEntrySummary;
            var blogService = new BlogService();
            var entry = await blogService.GetPost(item.Url);
            
            Frame.Navigate(typeof(BlogPage), entry);
        }
    }
}
