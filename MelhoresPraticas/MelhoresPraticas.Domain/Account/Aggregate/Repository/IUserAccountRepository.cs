using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.Domain.Account.Aggregate.Repository
{
    public interface IUserAccountRepository
    {
        List<UserAccount> GetAll();
    }
}
