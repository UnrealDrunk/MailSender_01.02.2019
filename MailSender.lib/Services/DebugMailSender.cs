using MailSender.lib.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace MailSender.lib.Services
{
    public class DebugMailSender
    {
        private readonly Server _Server;

        public DebugMailSender(Server Server)
        {
            _Server = Server;
  
        }

        public void Send( Mail Mail, Sender From, Recipients To)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]\r\n{5}:{6}",
                From.Adress, To.Adress, _Server.Adress, _Server.Port,
                _Server.UseSSL ? "SSL" : "no SSL", Mail.Subject, Mail.Body);
        }




        public void Send(Mail Message, Sender From, IEnumerable<Recipients> To)
        {
            foreach (var recipient in To)
            {
                Send(Message, From, recipient);
            }
        }


        public void SendParallel(Mail Message, Sender From, IEnumerable<Recipients> To)
        {
            foreach (var recipient in To)
            {
                ThreadPool.QueueUserWorkItem(_ => Send(Message, From, recipient));
            }
        }
    }




}
