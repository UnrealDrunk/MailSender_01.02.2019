using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class RecipientsStoreInMemory
    {
        public IEnumerable<Recipients> Get() => TestData.Recipients;

        public void Edit(int id, Recipients recipient)
        {
            // Так как это хранилище данных в памяти, то здесь ничего не делаем
        }


        public void SaveChanges()
        {
            // Так как это хранилище данных в памяти, то здесь ничего не делаем

        }


    }




}
