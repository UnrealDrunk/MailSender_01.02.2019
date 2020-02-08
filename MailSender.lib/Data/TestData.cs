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
            new Server{Id=0, Name ="Яндекс", Adress = "smpt.yandex.ru", Port = 587, Login = "UserLogin",
                Password = TextEncoder.Encode("Password")},
            new Server{Id =1, Name ="Mail.ru", Adress = "smpt.mail.ru", Port = 587, Login = "UserLogin",
                Password = TextEncoder.Encode("Password") },
            new Server{Id =2, Name ="GMail", Adress = "smpt.gmail.com", Port = 587, Login = "UserLogin",
                Password = TextEncoder.Encode("Password") }

        };

        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender{Id = 0, Name ="Иванов", Adress = "ivanov@server.ru"},
            new Sender{Id = 1, Name ="Петров", Adress = "petrov@server.ru"},
            new Sender{Id = 2, Name ="Сидоров", Adress = "sidorov@server.ru"},

        };

        public static List<Recipients> Recipients { get; } = new List<Recipients>
        {
            new Recipients{Id = 0, Name ="Иванов", Adress = "ivanov@server.ru"},
            new Recipients{Id = 1, Name ="Петров", Adress = "petrov@server.ru"},
            new Recipients{Id = 2, Name ="Сидоров", Adress = "sidorov@server.ru"},

        };






    }
}
