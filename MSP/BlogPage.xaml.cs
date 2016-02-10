using System.ComponentModel;
using MSP.Services.Model;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;

namespace MSP
{
    public sealed partial class BlogPage : INotifyPropertyChanged
    {
        DataTransferManager dtm;

        public BlogPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnChanged("Title");
                }
            }
        }

        private string _comment;
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnChanged("Comment");
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as BlogEntry;
            Title = param.Title;
            Comment = param.Comment;

            dtm = DataTransferManager.GetForCurrentView();
            dtm.DataRequested += dtm_DataRequested;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            dtm.DataRequested -= dtm_DataRequested;
        }

        void dtm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataPackage data = args.Request.Data;
            data.Properties.Title = Title;
            data.SetText(Comment);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
