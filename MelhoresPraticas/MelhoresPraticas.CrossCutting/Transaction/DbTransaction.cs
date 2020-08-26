using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace MelhoresPraticas.CrossCutting.Transaction
{
    public class DbTransaction : IDbTransaction
    {
        private bool disposedValue;

        private IDbContextTransaction DbContextTransaction { get; set; }

        public DbTransaction() { }

        public DbTransaction(IDbContextTransaction dbContextTransaction)
        {
            this.DbContextTransaction = dbContextTransaction;
        }

        public void Commit()
        {
            this.DbContextTransaction.Commit();
        }

        public void Rollback()
        {
            this.DbContextTransaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DbTransaction()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
