using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.CrossCutting.Transaction
{
    public interface IDbTransaction : IDisposable
    {
        void Rollback();
        void Commit();
    }
}
