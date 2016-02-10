using System.Collections.ObjectModel;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using MSP.Common;
using MSP.Services;
using MSP.Services.Model;

namespace MSP.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IPersonService _personService;
        private readonly IImagineCupService _imagineCupService;
        private readonly IDreamsparkService _dreamsparkService;
        private readonly IBlogService _blogService;

        private bool blogLoaded, teamLoaded;

        public MainViewModel(IImagineCupService imagineCupService,
            IPersonService personService,
            IDreamsparkService dreamsparkService,
            IBlogService blogService)
        {
            _personService = personService;
            _imagineCupService = imagineCupService;
            _dreamsparkService = dreamsparkService;
            _blogService = blogService;

            blogLoaded = teamLoaded = false;
            ProgressBarVisibility = "Visible";
            IsIndeterminate = "True";
            GridVisibility = "Collapsed";
            ProgressRingVisibility = "Visible";
            ProgressRingActive = "True";

            LoadPeople();
            LoadEntries();

            ImagineCupDescription = _imagineCupService.GetDescription();
            ImagineCupImage = _imagineCupService.GetImageUrl();
            Prizes = _imagineCupService.GetPrizes();
            DreamsparkDescription = _dreamsparkService.GetBriefDescription();
        }

        private string _visibility;
        public string ProgressBarVisibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                if ((teamLoaded && blogLoaded) || (!teamLoaded && !blogLoaded))
                {
                    _visibility = value;
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
                if ((teamLoaded && blogLoaded) || (!teamLoaded && !blogLoaded))
                {
                    _indeterminate = value;
                    OnChanged("IsIndeterminate");
                }
            }
        }

        private string _progressRingVisibility;
        public string ProgressRingVisibility
        {
            get
            {
                return _progressRingVisibility;
            }
            set
            {
                if ((teamLoaded && blogLoaded) || (!teamLoaded && !blogLoaded))
                {
                    _progressRingVisibility = value;
                    OnChanged("ProgressRingVisibility");
                }
            }
        }

        private string _progressRingActive;
        public string ProgressRingActive
        {
            get
            {
                return _progressRingActive;
            }
            set
            {
                if ((teamLoaded && blogLoaded) || (!teamLoaded && !blogLoaded))
                {
                    _progressRingActive = value;
                    OnChanged("ProgressRingActive");
                }
            }
        }

        private string _gridVisibility;
        public string GridVisibility
        {
            get
            {
                return _gridVisibility;
            }
            set
            {
                if ((teamLoaded && blogLoaded) || (!teamLoaded && !blogLoaded))
                {
                    _gridVisibility = value;
                    OnChanged("GridVisibility");
                }
            }
        }

        #region Blog
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
            OnChanged("Entries");
            
            blogLoaded = true;
            
            ProgressBarVisibility = "Collapsed";
            IsIndeterminate = "False";
            GridVisibility = "Visible";
            ProgressRingVisibility = "Collapsed";
            ProgressRingActive = "False";
        }
        #endregion

        #region Dreamspark
        public string DreamsparkDescription { get; set; }
        #endregion

        #region ImagineCup
        public string ImagineCupDescription { get; set; }
        public string ImagineCupImage { get; set; }
        public string Prizes { get; set; }
        #endregion

        #region Echipa
        public string BigImage
        {
            get
            {
                return "http://www.microsoft.pub.ro/Themes/Contoso/Content/Images/Slide_1.jpg";
            }
        }

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get
            {
                if (_people == null)
                {
                    _people = new ObservableCollection<Person>();
                }

                return _people;
            }
        }

        private async void LoadPeople()
        {
            var personList = await _personService.GetPeople();

            personList.Shuffle();
            People.AddRange(personList);

            teamLoaded = true;
            ProgressBarVisibility = "Collapsed";
            IsIndeterminate = "False";
            GridVisibility = "Visible";
            ProgressRingVisibility = "Collapsed";
            ProgressRingActive = "False";
        }
        #endregion

        #region Contact
        public string ContactImage
        {
            get
            {
                return "http://www.microsoft.pub.ro/Media/Default/Images/hartalab.png";
            }
        }
        #endregion

        public PropertyChangedEventHandler _propertyChanged;
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