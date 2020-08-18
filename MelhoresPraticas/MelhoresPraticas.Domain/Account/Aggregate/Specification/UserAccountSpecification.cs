using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.Domain.Account.Aggregate.Specification
{
    public class UserAccountSpecification
    {
        public static ISpecification<UserAccount> GetByCPF(string cpf)
        {
            Specification<UserAccount> spec = new Specification<UserAccount>(x => x.CPF == cpf);
            return spec;
        }

        public static ISpecification<UserAccount> GetByEmail(string email)
        {
            Specification<UserAccount> spec = new Specification<UserAccount>(x => x.Email == email);
            return spec;
        }

    }
}
