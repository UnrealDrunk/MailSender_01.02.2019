using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Iterfaces2;

namespace MailSender.lib.Services
{


    public class RecipientsStoreInMemory : DataStoreInMemeory<Recipients>, IRecipientsStore
    {

        public RecipientsStoreInMemory(): base(TestData.Recipients) { }


        public override void Edit(int id, Recipients recipient)
        {
            var db_recipient = GetById(id);
            if (db_recipient is null) return;

            //делаем вид, что мы работаем не с объектами в памяти,
            //а с объектами в базе данных
            db_recipient.Name = recipient.Name;
            db_recipient.Adress = recipient.Adress;
        }




    }
}
