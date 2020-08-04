using MelhoresPraticas.Domain.Account.Aggregate;
using MelhoresPraticas.Domain.Account.Aggregate.Repository;
using MelhoresPraticas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelhoresPraticas.Repository.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private MelhoresPraticasContext Context { get; set; }

        public UserAccountRepository(MelhoresPraticasContext context)
        {
            this.Context = context;
        }

        public List<UserAccount> GetAll()
        {
            return this.Context.UserAccounts.ToList();
        }
    }
}
