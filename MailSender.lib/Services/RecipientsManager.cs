﻿using System;
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
        private IRecipientsStore _Store;

        public RecipientsManager(IRecipientsStore Store)
        {
            _Store = Store;
        }


        public IEnumerable<Recipients> GetAll()
        {
            return _Store.GetAll();
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
