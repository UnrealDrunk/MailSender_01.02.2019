using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entities.Base;


namespace MailSender.lib.Entities
{
    public class Sender: PersonEntity
    {


        public override string ToString() => $"{Name}:{Adress}";
        

    }
}
