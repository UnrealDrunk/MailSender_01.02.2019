using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MailSender.lib.Entities;
using MailSender_01._02._2019.Infrastructure.Services.Interfaces;


namespace MailSender_01._02._2019.Infrastructure.Services
{
    public class WindowSenderEditor : ISenderEditor
    {
        public void Edit(Sender sender)
        {
            var current_main_window = (MainWindow)Application.Current.MainWindow;
            var editor = new SenderEditor(sender, current_main_window);
            editor.Owner = current_main_window;
            if (editor.ShowDialog() != true) return;
            sender.Name = editor.Name;
            sender.Adress = editor.AddressValue;

        }
    }
}
