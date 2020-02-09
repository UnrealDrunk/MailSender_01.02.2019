using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Services.Iterfaces2;

namespace MailSender.lib.Services
{
    public class RecipientsManager : IrecipientManager
    {
        private RecipientsStoreInMemory _Store;

        public RecipientsManager(RecipientsStoreInMemory Store)
        {
            _Store = Store;
        }


        public IEnumerable<Recipients> GetAll()
        {
            return _Store.Get();
        }


        public void Add(Recipients NewRecipient)
        {

        }

        public void Edit(Recipients Recipient)
        {
            _Store.Edit(Recipient.Id, Recipient);
        }


        public void SaveChanges()
        {
            _Store.SaveChanges();
        }



        //Edit(recipients)
        //delete


    }
}
