using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Iterfaces2
{
    interface IRecipientsStore
    {
        IEnumerable<Recipients> Get();

        void Edit(int id, Recipients recipient);

        void SaveChanges();
    }
}
