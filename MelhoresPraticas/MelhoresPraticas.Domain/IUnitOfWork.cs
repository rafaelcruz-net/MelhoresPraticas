using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace MelhoresPraticas.Domain
{
    public interface IUnitOfWork
    {
        MelhoresPraticas.CrossCutting.Transaction.IDbTransaction CreateTransaction();
        MelhoresPraticas.CrossCutting.Transaction.IDbTransaction CreateTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();

    }
}
