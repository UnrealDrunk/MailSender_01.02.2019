using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security;
using MailSender.lib.Entities;
using System.Threading;

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

        public void Send(Mail Message, Sender From, IEnumerable<Recipients> To)
        {
            foreach(var recipient in To)
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



        public async Task SendAsync(Mail Mail, Sender From, Recipients To)
        {
            using (var message = new MailMessage(new MailAddress(From.Adress, From.Name),
                new MailAddress(To.Adress, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var _login = new NetworkCredential(_Server.Login, _Server.Password);
                using (var client = new SmtpClient(_Server.Adress, _Server.Port) { EnableSsl = _Server.UseSSL, Credentials = _login })
                    //client.Send(message);
                    await client.SendMailAsync(message).ConfigureAwait(false);

            }
        }

        //public async Task SendAsync(Mail Message, Sender From, IEnumerable<Recipients> To)
        //{
        //    await Task.WhenAll(To.Select(to => SendAsync(Message, From, to))).ConfigureAwait(false);
        //}

        public async Task SendAsync(Mail Message, Sender From, IEnumerable<Recipients> To, CancellationToken Cancel = default)
        {
            foreach(var recipient in To)
            {
                Cancel.ThrowIfCancellationRequested();
                await SendAsync(Message, From, recipient).ConfigureAwait(false);
            }
        }


    }




}
