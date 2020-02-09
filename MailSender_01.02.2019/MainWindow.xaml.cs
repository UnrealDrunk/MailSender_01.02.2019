using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailSender.lib.Entities;
using MailSender.lib.Services;
using MailSender.lib.Service;

namespace MailSender_01._02._2019
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSendButtonClick(object Sender, RoutedEventArgs e)
        {
            //var recipient = RecipientsList.SelectedItem as Recipients;
            //var sender = SenderList.SelectedItem as Sender;
            //var server = ServersList.SelectedItem as Server;

            //if (recipient is null || server is null || sender is null)
            //    return;

            //var mailSender = new MailSender.lib.Services.DebugMailSender(server.Adress, server.Port, server.UseSSL,
            //    server.Login, server.Password.Decode(3));

            //mailSender.Send(MailHeader.Text, MailBody.Text, sender.Adress, recipient.Adress);
            
        }

        private void OnSenderEditClick(object Sender, RoutedEventArgs e)
        {
            var sender = SenderList.SelectedItem as Sender;
            if (sender is null) return;

            var dialog = new SenderEditor(sender, this);

            if (dialog.ShowDialog() != true) return;

            // Внести изменения в sender

            sender.Name = dialog.NameValue;
            sender.Adress = dialog.AddressValue;

        }

        private void RecipientsView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
