using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security;
using System.Diagnostics;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private string serverAdress;
        private readonly int port;
        private bool useSsl;
        private string login;
        private string password;


        public MailSender(string serverAdress, int port, bool useSsl, string login, string password)
        {
            this.serverAdress = serverAdress;
            this.port = port;
            this.useSsl = useSsl;
            this.login = login;
            this.password = password;
        }

        public void Send(string subject, string body, string from, string to)
        {
            using (var message = new MailMessage(from, to))
            {
                message.Subject = subject;
                message.Body = body;

                var _login = new NetworkCredential(login, password);
                using (var client = new SmtpClient(serverAdress, port) { EnableSsl = useSsl, Credentials = _login })
                    client.Send(message);
                    
               
            }
        }
    }

    public class DebugMailSender
    {
        private string serverAdress;
        private readonly int port;
        private bool useSsl;
        private string login;
        private string password;


        public DebugMailSender(string serverAdress, int port, bool useSsl, string login, string password)
        {
            this.serverAdress = serverAdress;
            this.port = port;
            this.useSsl = useSsl;
            this.login = login;
            this.password = password;
        }

        public void Send(string subject, string body, string from, string to)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[{4}]\r\n{5}:{6}", from, to, serverAdress, port,
                useSsl ? "SSL" : "no SSL", subject, body);
        }
    }




}
