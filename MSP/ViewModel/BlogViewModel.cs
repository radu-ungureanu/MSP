using System.Collections.ObjectModel;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using MSP.Common;
using MSP.Services;
using MSP.Services.Model;

namespace MSP.ViewModel
{
    public class BlogViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IBlogService _blogService;

        public BlogViewModel(IBlogService blogService)
        {
            _blogService = blogService;

            ProgressBarVisibility = "Visible";
            IsIndeterminate = "True";
            
            LoadEntries();
        }

        private string _progressBarVisibility;
        public string ProgressBarVisibility
        {
            get
            {
                return _progressBarVisibility;
            }
            set
            {
                if (_progressBarVisibility != value)
                {
                    _progressBarVisibility = value;
                    OnChanged("ProgressBarVisibility");
                }
            }
        }

        private string _indeterminate;
        public string IsIndeterminate
        {
            get
            {
                return _indeterminate;
            }
            set
            {
                if (_indeterminate != value)
                {
                    _indeterminate = value;
                    OnChanged("IsIndeterminate");
                }
            }
        }

        private ObservableCollection<BlogEntrySummary> _entries;
        public ObservableCollection<BlogEntrySummary> Entries
        {
            get
            {
                if (_entries == null)
                {
                    _entries = new ObservableCollection<BlogEntrySummary>();
                }

                return _entries;
            }

            set
            {
                if (_entries != null)
                    _entries.Clear();
                _entries = value;
            }
        }

        private async void LoadEntries()
        {
            var entries = await _blogService.GetPreviewPosts();

            Entries.AddRange(entries);

            ProgressBarVisibility = "Collapsed";
            IsIndeterminate = "False";
        }

        private PropertyChangedEventHandler _propertyChanged;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { this._propertyChanged += value; }
            remove { this._propertyChanged -= value; }
        }

        private void OnChanged(string propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}