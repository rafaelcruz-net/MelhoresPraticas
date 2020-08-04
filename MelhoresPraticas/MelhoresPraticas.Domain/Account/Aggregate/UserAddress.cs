using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.Domain.Account.Aggregate
{
    public class UserAddress
    {
        public Guid Id { get; set; }

        public String Address { get; set; }

        public String Complement { get; set; }

        public String Neiborhood { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public String ZipCode { get; set; }
    }
}
