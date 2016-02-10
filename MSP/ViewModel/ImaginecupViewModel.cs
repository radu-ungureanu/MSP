using GalaSoft.MvvmLight;
using MSP.Services;

namespace MSP.ViewModel
{
    public class ImaginecupViewModel : ViewModelBase
    {
        private readonly IImagineCupService _imagineCupService;

        public ImaginecupViewModel(IImagineCupService imagineCupService)
        {
            _imagineCupService = imagineCupService;

            ImagineCupImage = _imagineCupService.GetImageUrl();
            Description = _imagineCupService.GetDescription();
            Reasons = _imagineCupService.GetReasons();
            Prizes = _imagineCupService.GetPrizes();
            Grants = _imagineCupService.GetGrants();
            HowToParticipate = _imagineCupService.GetHowToParticipate();
            Participation = _imagineCupService.GetParticipation();
            Deadline = _imagineCupService.GetDeadline();
        }

        public string ImagineCupImage { get; set; }
        public string Description { get; set; }
        public string Reasons { get; set; }
        public string Prizes { get; set; }
        public string Grants { get; set; }
        public string HowToParticipate { get; set; }
        public string Participation { get; set; }
        public string Deadline { get; set; }
    }
}