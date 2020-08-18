using MelhoresPraticas.Domain.Account.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MelhoresPraticas.ApplicationServices.Account
{
    public interface IAccountService
    {
        Task CreateAccount(UserAccount userAccount);
    }
}
