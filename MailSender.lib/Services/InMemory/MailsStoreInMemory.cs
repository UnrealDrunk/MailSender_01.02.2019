using MailSender.lib.Entities;
using MailSender.lib.Services.Iterfaces2;
using System.Linq;

namespace MailSender.lib.Services
{
    public class MailsStoreInMemory : DataStoreInMemeory<Mail>, IMailStore
    {

        public MailsStoreInMemory() : base(Enumerable.Range(1,10).Select(i => new Mail
        { Id = 1, Subject = $"Message {i}", Body = $"Message body {i}" }).ToList())
        {

        }



        public override void Edit(int id, Mail recipient)
        {
            var db_recipient = GetById(id);
            if (db_recipient is null) return;

            db_recipient.Subject = recipient.Subject;
            db_recipient.Body = recipient.Body;
        }




    }



}
