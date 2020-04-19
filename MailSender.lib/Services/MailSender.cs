using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private readonly Server _Server;

        public MailSender(Server Server) => _Server = Server;

        public void Send(Mail Mail, Sender From, Recipients To)
        {
            using (var message = new MailMessage(new MailAddress(From.Adress, From.Name), 
                new MailAddress(To.Adress, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var _login = new NetworkCredential(_Server.Login, _Server.Password);
                using (var client = new SmtpClient(_Server.Adress, _Server.Port) { EnableSsl = _Server.UseSSL, Credentials = _login })
                    client.Send(message);
                    
               
            }
        }
    }




}
