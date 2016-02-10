using GalaSoft.MvvmLight;

namespace MSP.ViewModel
{
    public class ContactViewModel : ViewModelBase
    {
        public string ContactImage
        {
            get
            {
                return "http://www.microsoft.pub.ro/Media/Default/Images/hartalab.png";
            }
        }

        public string Credentials
        {
            get
            {
                return "AuzGPxXlwE0DzDiAenZ0DBCFCbCjsV5su738h9-T_GGmpz22pA3eFt9QH4hUTT2b";
            }
        }

        public string Longitude
        {
            get
            {
                return "26.047787";
            }
        }

        public string Latitude
        {
            get
            {
                return "44.436367";
            }
        }

        public string Zoom
        {
            get
            {
                return "16";
            }
        }
    }
}