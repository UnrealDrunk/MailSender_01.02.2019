﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entities
{
    public class Sender
    {
        public string Name { get; set; }

        public string Adress { get; set; }

        public override string ToString() => $"{Name}:{Adress}";
        

    }
}