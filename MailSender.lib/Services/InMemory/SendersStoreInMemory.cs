using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Iterfaces2;

namespace MailSender.lib.Services
{
    public class SendersStoreInMemory : DataStoreInMemeory<Sender>, ISenderStore
    {

        public SendersStoreInMemory() : base(TestData.Senders) { }


        public override void Edit(int id, Sender sender)
        {
            var db_sender = GetById(id);
            if (db_sender is null) return;

            db_sender.Name = sender.Name;
            db_sender.Adress = sender.Adress;
        }




    }




}
