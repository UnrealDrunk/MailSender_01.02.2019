using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Recipients: PersonEntity, IDataErrorInfo
    {

        public override string Name
        {
            get => base.Name;
            set
            {
                if (value == "Быков")
                    throw new ArgumentException("Быков нам не подходит", nameof(value));
                base.Name = value;
            }
        }


        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    default: return null;

                    case nameof(Name):
                        var name = Name;
                        if (name is null) return "Пустая ссылка на имя";
                        if (name.Length < 2) return "Имя должно содержать более двух символов";
                        if (name.Length > 20) return "Превышена допустимая длинна имени в 20 символов";

                        return null;
                }
            }
        }

        string IDataErrorInfo.Error => null;
    }

}
