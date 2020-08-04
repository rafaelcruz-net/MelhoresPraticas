using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.Domain.Account.Aggregate
{
    public class UserAccount
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String CPF { get; set; }

        public String Email { get; set; }

        public DateTime DtBirthday { get; set; }

        public String UserName { get; set; }

        public IList<UserAddress> Addresses { get; set; }

        public IList<UserPhone> Phones { get; set; }

    }
}
