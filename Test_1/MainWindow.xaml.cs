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
using System.Net.Mail;
using System.Net;
using System.Security;
using System.Threading;
//using Test_1.ViewModels;

namespace Test_MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new MainWindowViewModel();
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            const string message = "Hello World!!!";
            var result = GetMessageLength(message);
            Result.Text = result.ToString();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private Task<int>GetMessageLengthAsync(string Message, int Timeout = 30)
        {
            return Task.Run(() => GetMessageLength(Message, Timeout));
        }

        private int _StartCount;
        private int GetMessageLength(string Message, int Timeout = 30)
        {
            for (var i =0; i < 100; i++)
            {
                Thread.Sleep(Timeout);
            }

            return Message.Length + _StartCount++;
        }
    }
}