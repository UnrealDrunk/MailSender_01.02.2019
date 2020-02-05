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
using System.Windows.Shapes;
using MailSender.lib.Entities;

namespace MailSender_01._02._2019
{

    public partial class SenderEditor
    {
        private MainWindow MainWindow;

        public string NameValue { get => NameEditor.Text; set => NameEditor.Text = value; }
        public string AddressValue { get => AddressEditor.Text; set => AddressEditor.Text = value; }

        public SenderEditor(Sender Sender, MainWindow mainWindow)
        {
            InitializeComponent();
            NameValue = Sender.Name;
            AddressValue = Sender.Adress;
            MainWindow = mainWindow;
        }

       

        private void OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OnCloseMainWindowClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Title += " Hello World!!!";
        }
    }
}
