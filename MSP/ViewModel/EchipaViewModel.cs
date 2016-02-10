using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;
using MSP.Common;
using MSP.Services;
using MSP.Services.Model;

namespace MSP.ViewModel
{
    public class EchipaViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly IPersonService _personService;

        public EchipaViewModel(IPersonService personService)
        {
            _personService = personService;

            MembriVisibility = "Collapsed";
            AlumnusVisibility = "Collapsed";
            WannabeVisibility = "Collapsed";

            ProgressBarVisibility = "Visible";
            IsIndeterminate = "True";

            LoadPeople();
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

            set
            {
                if (_people != null)
                    _people.Clear();
                _people = value;
            }
        }

        private ObservableCollection<Person> _membri;
        public ObservableCollection<Person> Membri
        {
            get
            {
                if (_membri == null)
                {
                    _membri = new ObservableCollection<Person>();
                }

                return _membri;
            }
        }

        private ObservableCollection<Person> _wannabe;
        public ObservableCollection<Person> Wannabe
        {
            get
            {
                if (_wannabe == null)
                {
                    _wannabe = new ObservableCollection<Person>();
                }

                return _wannabe;
            }
        }

        private ObservableCollection<Person> _alumnus;
        public ObservableCollection<Person> Alumnus
        {
            get
            {
                if (_alumnus == null)
                {
                    _alumnus = new ObservableCollection<Person>();
                }

                return _alumnus;
            }
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

        private string _membriVisibility;
        public string MembriVisibility
        {
            get
            {
                return _membriVisibility;
            }
            set
            {
                if (_membriVisibility != value)
                {
                    _membriVisibility = value;
                    OnChanged("MembriVisibility");
                }
            }
        }

        private string _alumnusVisibility;
        public string AlumnusVisibility
        {
            get
            {
                return _alumnusVisibility;
            }
            set
            {
                if (_alumnusVisibility != value)
                {
                    _alumnusVisibility = value;
                    OnChanged("AlumnusVisibility");
                }
            }
        }

        private string _wannabeVisibility;
        public string WannabeVisibility
        {
            get
            {
                return _wannabeVisibility;
            }
            set
            {
                if (_wannabeVisibility != value)
                {
                    _wannabeVisibility = value;
                    OnChanged("WannabeVisibility");
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

        public async void LoadPeople()
        {
            var _people = await _personService.GetPeople();

            People.AddRange(_people);
            Membri.AddRange(People.Where(t => !t.Position.Contains("Wannabe") && !t.Position.Contains("Alumnus")));
            Wannabe.AddRange(People.Where(t => t.Position.Contains("Wannabe")));
            Alumnus.AddRange(People.Where(t => t.Position.Contains("Alumnus")));

            if (Membri.Count != 0)
                MembriVisibility = "Visible";
            if (Alumnus.Count != 0)
                AlumnusVisibility = "Visible";
            if (Wannabe.Count != 0)
                WannabeVisibility = "Visible";

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