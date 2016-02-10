using MSP.MSPDataServices;
using MSP.Services.Model;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MSP
{
    public sealed partial class BlogSummaryPage
    {
        public BlogSummaryPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void gridBlog_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            progressBar.IsIndeterminate = true;
            progressBar.Visibility = Windows.UI.Xaml.Visibility.Visible;

            var item = e.ClickedItem as BlogEntrySummary;
            var blogService = new BlogService();
            var entry = await blogService.GetPost(item.Url);

            Frame.Navigate(typeof(BlogPage), entry);
        }
    }
}
