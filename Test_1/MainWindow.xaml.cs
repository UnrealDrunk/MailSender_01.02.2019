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

        private CancellationTokenSource _ProcessCancelation;

        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button)) return;
            button.IsEnabled = false;

            var cancelation = new CancellationTokenSource();
            //Interlocked.Exchange(ref _ProcessCancelation, cancelation)?.Cancel(); // более правильный подход для многопоточного прграммирования
            _ProcessCancelation?.Cancel();
            _ProcessCancelation = cancelation;

            const string message = "Hello World!!!";
            Result.Text = "Начался расчёт";

            IProgress<int> progress = new Progress<int>(p => _Progress.Value = p);
            

            try
            {
                var result = await GetMessageLengthAsync(message, 30, progress, cancelation.Token).ConfigureAwait(true);
                progress.Report(0);
                Result.Text = result.ToString();
            }
            catch (OperationCanceledException)
            {

                Result.Text = "Выполнен сброс";
                progress.Report(0);
            }

            button.IsEnabled = true;
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            _ProcessCancelation?.Cancel();
            Result.Text = "Выполнен сброс";
        }

        private async Task<int>GetMessageLengthAsync(string Message, int Timeout = 30, IProgress<int> Progress = null, CancellationToken Cancel = default)
        {
            return await Task.Run(() => GetLengthAsync(Message, Timeout, Progress, Cancel)).ConfigureAwait(false);
        }

        private int _StartCount;

        private async Task<int> GetLengthAsync(string Message, int Timeout = 30, IProgress<int> Progress = null, CancellationToken Cancel = default)
        {
            for (var i =0; i < 100; i++)
            {
                await Task.Delay(Timeout, Cancel);
                if (Cancel.IsCancellationRequested)
                {
                    Progress?.Report(0);
                }
                else
                {
                    Progress?.Report(i);
                }

                Cancel.ThrowIfCancellationRequested();
            }

            return Message.Length + _StartCount++;
        }

        private int GetMessageLength(string Message, int Timeout = 30, IProgress<int> Progress = null, CancellationToken Cancel = default)
        {
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(Timeout);
                Progress?.Report(i);
                Cancel.ThrowIfCancellationRequested();
            }

            return Message.Length + _StartCount++;
        }


    }
}