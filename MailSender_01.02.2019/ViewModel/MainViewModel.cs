using GalaSoft.MvvmLight;

namespace MailSender_01._02._2019.ViewModel
{
 
    public class MainViewModel : ViewModelBase
    {

        private string _Title = "Mail Sender";


        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ///


        }
    }
}