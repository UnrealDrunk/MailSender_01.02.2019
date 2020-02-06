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
                if (Set(ref _Title, value))
                    OnPropertyChanged(nameof(TitleLength));
            }

            //set => Set(ref _Title, value);
            //set
            //{
            //    if (Equals(_Title, value)) return;
            //    _Title = value;
            //    //OnPropertyChanged("Title");
            //    OnPropertyChanged();
            //}
        }

        public int TitleLength => _Title.Length;

        private string _TestValue = "90";

        public string TestValue
        {
            get => _TestValue;
            set => Set(ref _TestValue, value);
        }

        private double _X;
        private double _Y;

        public double X
        {
            get => _X;
            set => Set(ref _X, value);
        }

        public double Y
        {
            get => _Y;
            set => Set(ref _Y, value);
        }
    }
}
