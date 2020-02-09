using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Iterfaces2
{
    public interface IrecipientManager
    {
        IEnumerable<Recipients> GetAll();

        void Add(Recipients NewRecipient);

        void Edit(Recipients Recipient);

        void SaveChanges();
    }
}
