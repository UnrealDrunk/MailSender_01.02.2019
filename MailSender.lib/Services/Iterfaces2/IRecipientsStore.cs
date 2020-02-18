using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Iterfaces2
{
    public interface IRecipientsStore
    {
        IEnumerable<Recipients> GetAll();

        Recipients GetById(int id);

        int Create(Recipients Recipient);

        void Edit(int id, Recipients Recipient);

        Recipients Remove(int id);

        void SaveChanges();
    }
}
