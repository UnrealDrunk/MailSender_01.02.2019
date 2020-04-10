using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services.Iterfaces2;

namespace MailSender.lib.Services
{
    public class ServersStoreInMemory : DataStoreInMemeory<Server>, IServersStore
    {

        public ServersStoreInMemory() : base(TestData.Servers) { }


        public override void Edit(int id, Server server)
        {
            var db_server = GetById(id);
            if (db_server is null) return;

            db_server.Name = server.Name;
            db_server.Adress = server.Adress;
            db_server.Port = server.Port;
            db_server.UseSSL = server.UseSSL;
            db_server.Login = server.Login;
            db_server.Password = server.Password;

        }




    }



}
