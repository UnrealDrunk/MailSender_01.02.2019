using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.MVVM;

namespace Test_1.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Наше новое окно!!!";


        public string Title
        {
            get => _Title;
            set
            {
                if (Equals(_Title, value)) return;
                _Title = value;
                //OnPropertyChanged("Title");
                OnPropertyChanged();
            }
        }

    }
}
