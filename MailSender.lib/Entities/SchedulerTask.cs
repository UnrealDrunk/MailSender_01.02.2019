using MailSender.lib.Entities.Base;
using System;

namespace MailSender.lib.Entities
{
    /// <summary>Задача планировщика</summary>
    public class SchedulerTask: BaseEntity
    {
        /// <summary>Время выполнения задания</summary>
        public DateTime Time { get; set; }

        /// <summary>Отправитель почты в задании</summary>
        public Sender Sender { get; set; }

        /// <summary>Список получателей писем</summary>
        public MailingList Recipients { get; set; }

        /// <summary>Сервер, через который необходимо выполнить отправку почты</summary>
        public Server Server { get; set; }

        /// <summary>Письмо, которое требуется разослатьт</summary>
        public Mail Mail { get; set; }
    }

}
