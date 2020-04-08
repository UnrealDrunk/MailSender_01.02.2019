using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSender.lib.Services;


namespace MailSender.lib.Tests.Services
{
    [TestClass]
    public class RecipientStoreInMemoryTests
    {
        [TestMethod,ExpectedException(typeof(ArgumentNullException))]
        public void Create_throw_ArgumentNullException_if_items_is_null()
        {
            var store = new RecipientsStoreInMemory();

            store.Create(null);
        }


        [TestMethod]
        public void Create_throw_ArgumentNullException_if_items_is_null2()
        {
            var store = new RecipientsStoreInMemory();

            Assert.ThrowsException<ArgumentNullException>(() => store.Create(null));

        }

    }
}
