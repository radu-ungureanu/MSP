using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MSP.MSPDataServices;
using MSP.Services;

namespace MSP.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IPersonService, PersonService>();
            SimpleIoc.Default.Register<IImagineCupService, ImagineCupService>();
            SimpleIoc.Default.Register<IDreamsparkService, DreamsparkService>();
            SimpleIoc.Default.Register<IBlogService, BlogService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<BlogViewModel>();
            SimpleIoc.Default.Register<OrarViewModel>();
            SimpleIoc.Default.Register<DreamsparkViewModel>();
            SimpleIoc.Default.Register<ImaginecupViewModel>();
            SimpleIoc.Default.Register<EchipaViewModel>();
            SimpleIoc.Default.Register<ContactViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public BlogViewModel Blog
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BlogViewModel>();
            }
        }

        public OrarViewModel Orar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrarViewModel>();
            }
        }

        public DreamsparkViewModel Dreamspark
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DreamsparkViewModel>();
            }
        }

        public ImaginecupViewModel Imaginecup
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ImaginecupViewModel>();
            }
        }

        public EchipaViewModel Echipa
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EchipaViewModel>();
            }
        }

        public ContactViewModel Contact
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ContactViewModel>();
            }
        }
    }
}