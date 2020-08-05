using MelhoresPraticas.Domain.Account.Aggregate;
using MelhoresPraticas.Domain.Account.Aggregate.Repository;
using MelhoresPraticas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelhoresPraticas.Repository.Repository
{
    public class UserAccountRepository : RepositoryBase<UserAccount>, IUserAccountRepository
    {
        private MelhoresPraticasContext Context { get; set; }

        public UserAccountRepository(MelhoresPraticasContext context) : base(context)
        {
            this.Context = context;
        }




    }
}
