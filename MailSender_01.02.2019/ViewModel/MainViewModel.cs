using GalaSoft.MvvmLight;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using System.Collections.ObjectModel;

namespace MailSender_01._02._2019.ViewModel
{
 
    public class MainViewModel : ViewModelBase
    {
        private readonly RecipientsManager _RecipientsManager;

        private string _Title = "Mail Sender";


        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public ObservableCollection<Recipients> _Recipients;

        public ObservableCollection<Recipients> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        private Recipients _SelectedRecipient;

        public Recipients SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }


        public MainViewModel(RecipientsManager RecipientsManager)
        {

            _RecipientsManager = RecipientsManager;

            _Recipients = new ObservableCollection<Recipients>(_RecipientsManager.GetAll());

        }
    }
}