using GalaSoft.MvvmLight;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

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

        #region Commands

        public ICommand LoadRecipientsDataCommand { get; }

        public ICommand SaveRecipientChangesCommand { get; }

        #endregion


        public MainViewModel(RecipientsManager RecipientsManager)
        {

            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientDataCommandExecuted,
                CanLoadRecipientDataCommandExecute);

            SaveRecipientChangesCommand = new RelayCommand<Recipients>(OnSaveRecipientChangesCommandExecuted,
                CanSaveRecipientChangesCommandExecute);

            _RecipientsManager = RecipientsManager;


        }


        private bool CanLoadRecipientDataCommandExecute() => true;

        private void OnLoadRecipientDataCommandExecuted()
        {
            Recipients = new ObservableCollection<Recipients>(_RecipientsManager.GetAll());

        }


        private bool CanSaveRecipientChangesCommandExecute(Recipients recipient) => recipient != null;

        private void OnSaveRecipientChangesCommandExecuted(Recipients recipient)
        {
            _RecipientsManager.Edit(recipient);
            _RecipientsManager.SaveChanges();

        }

    }
}