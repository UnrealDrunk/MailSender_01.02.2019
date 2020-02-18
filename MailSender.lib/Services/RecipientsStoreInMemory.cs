using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Iterfaces2;

namespace MailSender.lib.Services
{
    public class RecipientsStoreInMemory : IRecipientsStore
    {

        public IEnumerable<Recipients> GetAll() => TestData.Recipients;


        public Recipients GetById(int id) => TestData.Recipients.FirstOrDefault(r => r.Id == id);



        public int Create(Recipients Recipient)
        {
            if (TestData.Recipients.Contains(Recipient)) return Recipient.Id;
            Recipient.Id = TestData.Recipients.Count == 0 ? 1 : TestData.Recipients.Max(r => r.Id) + 1;
            TestData.Recipients.Add(Recipient);
            return Recipient.Id;
        }

        public void Edit(int id, Recipients recipient)
        {
            var db_recipient = GetById(id);
            if (db_recipient is null) return;

            //делаем вид, что мы работаем не с объектами в памяти,
            //а с объектами в базе данных
            db_recipient.Name = recipient.Name;
            db_recipient.Adress = recipient.Adress;
        }


        public Recipients Remove(int id)
        {
            var db_recipient = GetById(id);
            if(db_recipient != null)
            {
                TestData.Recipients.Remove(db_recipient);
            }
            return db_recipient;
        }

        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение изменений в хранилище получателей писем");
            //поскольку это хранилище данных в памяти, то здесь ничего не деалем
        }

    }




}
