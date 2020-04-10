using GalaSoft.MvvmLight;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MailSender.lib.Services.Iterfaces2;
using MailSender_01._02._2019.Infrastructure.Services.Interfaces;

namespace MailSender_01._02._2019.ViewModel
{
 
    public class MainViewModel : ViewModelBase
    {
        private readonly IrecipientManager _RecipientsManager;
        private readonly ISenderStore _SendersStore;
        private readonly IServersStore _ServersStore;
        private readonly IMailStore _MailsStore;
        private readonly ISenderEditor _SenderEditor;


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


        public ObservableCollection<Sender> _Senders;

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            private set => Set(ref _Senders, value);
        }


        public ObservableCollection<Server> _Servers;

        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            private set => Set(ref _Servers, value);
        }


        public ObservableCollection<Mail> _Mails;

        public ObservableCollection<Mail> Mails        {
            get => _Mails;
            private set => Set(ref _Mails, value);
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

        public ICommand SenderEditCommand { get; }

        #endregion

        private Sender _SelectedSender;
        private Server _SelectedServer;
        private Mail _SelectedMail;


        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }


        public Mail SelectedMail
        {
            get => _SelectedMail;
            set => Set(ref _SelectedMail, value);
        }




        public MainViewModel(ISenderStore SenderStore,
            IServersStore ServersStore, IMailStore MailStore,
            ISenderEditor SenderEditor, IrecipientManager RecipientsManager)
        {

            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientDataCommandExecuted,
                CanLoadRecipientDataCommandExecute);

            SaveRecipientChangesCommand = new RelayCommand<Recipients>(OnSaveRecipientChangesCommandExecuted,
                CanSaveRecipientChangesCommandExecute);

            SenderEditCommand = new RelayCommand<Sender>(OnSenderEditCommandExecuted, CanSenderEditCommandExecute);

            _RecipientsManager = RecipientsManager;
            _SendersStore = SenderStore;
            _ServersStore = ServersStore;
            _MailsStore = MailStore;
            _SenderEditor = SenderEditor;

        }

        private bool CanSenderEditCommandExecute(Sender sender) => sender != null;

        private void OnSenderEditCommandExecuted(Sender sender)
        {
            _SenderEditor.Edit(sender);
        }


        private bool CanLoadRecipientDataCommandExecute() => true;

        private void OnLoadRecipientDataCommandExecuted()
        {
            Recipients = new ObservableCollection<Recipients>(_RecipientsManager.GetAll());
            Senders = new ObservableCollection<Sender>(_SendersStore.GetAll());
            Servers = new ObservableCollection<Server>(_ServersStore.GetAll());
            Mails = new ObservableCollection<Mail>(_MailsStore.GetAll());


        }


        private bool CanSaveRecipientChangesCommandExecute(Recipients recipient) => recipient != null;

        private void OnSaveRecipientChangesCommandExecuted(Recipients recipient)
        {
            _RecipientsManager.Edit(recipient);
            _RecipientsManager.SaveChanges();

        }

    }
}