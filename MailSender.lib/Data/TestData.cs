using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Service;

namespace MailSender.lib.Data
{
    public static class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server{ Name ="Яндекс", Adress = "smpt.yandex.ru", Port = 587, Login = "UserLogin",
                Password = TextEncoder.Encode("Password")},
            new Server{ Name ="Mail.ru", Adress = "smpt.mail.ru", Port = 587, Login = "UserLogin",
                Password = TextEncoder.Encode("Password") },
            new Server{ Name ="GMail", Adress = "smpt.gmail.com", Port = 587, Login = "UserLogin",
                Password = TextEncoder.Encode("Password") }

        };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender{Name ="Иванов", Adress = "ivanov@server.ru"},
            new Sender{Name ="Петров", Adress = "petrov@server.ru"},
            new Sender{Name ="Сидоров", Adress = "sidorov@server.ru"},

        };

        public static List<Recipients> Recipients { get; } = new List<Recipients>
        {
            new Recipients{Name ="Иванов", Adress = "ivanov@server.ru"},
            new Recipients{Name ="Петров", Adress = "petrov@server.ru"},
            new Recipients{Name ="Сидоров", Adress = "sidorov@server.ru"},

        };






    }
}
