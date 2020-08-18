using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace MelhoresPraticas.Domain
{
    public interface IUnitOfWork
    {
        IDbContextTransaction CreateTransaction();

        IDbContextTransaction CreateTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();

    }
}
