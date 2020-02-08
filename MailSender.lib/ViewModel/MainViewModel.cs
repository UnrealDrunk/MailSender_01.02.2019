using GalaSoft.MvvmLight;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using System.Collections.ObjectModel;

namespace MailSender.lib.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly RecipientsManager _RecipientsManager;

        private string _Title = "Рассыльщик почты";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private ObservableCollection<Recipients> _Recipients = new ObservableCollection<Recipients>();

         public ObservableCollection<Recipients> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }
    

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(RecipientsManager RecipientsManager)
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

            _RecipientsManager = RecipientsManager;

            _Recipients = new ObservableCollection<Recipients>(_RecipientsManager.GetAll());

        }
    }
}