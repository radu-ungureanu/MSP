using GalaSoft.MvvmLight;
using MSP.Services;

namespace MSP.ViewModel
{
    public class DreamsparkViewModel : ViewModelBase
    {
        private readonly IDreamsparkService _dreamsparkService;

        public DreamsparkViewModel(IDreamsparkService dreamsparkService)
        {
            _dreamsparkService = dreamsparkService;

            Description = _dreamsparkService.GetDescription();
            Authentication1 = _dreamsparkService.GetAuthentication1();
            Authentication2 = _dreamsparkService.GetAuthentication2();
            AuthenticationImage1 = _dreamsparkService.GetImage1Url();
            AuthenticationImage2 = _dreamsparkService.GetImage2Url();
            AuthenticationImage3 = _dreamsparkService.GetImage3Url();
            Download1 = _dreamsparkService.GetDownload1();
            Download2 = _dreamsparkService.GetDownload2();
            Download3 = _dreamsparkService.GetDownload3();
            Download4 = _dreamsparkService.GetDownload4();
            DownloadImage1 = _dreamsparkService.GetDownloadImage1();
            DownloadImage2 = _dreamsparkService.GetDownloadImage2();
            DownloadImage3 = _dreamsparkService.GetDownloadImage3();
            DownloadImage4 = _dreamsparkService.GetDownloadImage4();
            Install = _dreamsparkService.GetInstall();
            Recommendation = _dreamsparkService.GetRecommendation();
        }

        public string Description { get; set; }

        public string Authentication1 { get; set; }
        public string Authentication2 { get; set; }
        public string AuthenticationImage1 { get; set; }
        public string AuthenticationImage2 { get; set; }
        public string AuthenticationImage3 { get; set; }

        public string Download1 { get; set; }
        public string DownloadImage1 { get; set; }
        public string Download2 { get; set; }
        public string DownloadImage2 { get; set; }
        public string Download3 { get; set; }
        public string DownloadImage3 { get; set; }
        public string Download4 { get; set; }
        public string DownloadImage4 { get; set; }
        public string Install { get; set; }
        public string Recommendation { get; set; }
    }
}