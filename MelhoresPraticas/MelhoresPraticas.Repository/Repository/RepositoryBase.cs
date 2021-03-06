﻿using MelhoresPraticas.Domain;
using MelhoresPraticas.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MelhoresPraticas.Repository.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private DbSet<T> Query { get; set; }
        private MelhoresPraticasContext Context { get; set; }

        public RepositoryBase(MelhoresPraticasContext context)
        {
            this.Context = context;
            this.Query = context.Set<T>();
        }

        public async Task Delete(object id)
        {
            var obj = await this.Query.FindAsync(id);
            this.Query.Remove(obj);
            this.Context.SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await this.Query.FindAsync(id);
        }

        public Task Save(T obj)
        {
            this.Query.Add(obj);
            this.Context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task Update(object id, T obj)
        {
            var objOld = await this.Query.FindAsync(id);

            objOld = obj;

            this.Query.Add(objOld);
            this.Context.Entry(objOld).State = EntityState.Modified;

            this.Context.SaveChanges();
        }

        public Task<T> GetOneByCriteria(ISpecification<T> spec)
        {
            return this.Query.FirstOrDefaultAsync(spec.SatisfyByCriteria());
        }

        public Task<IEnumerable<T>> GetAllByCriteria(ISpecification<T> spec)
        {
            return Task.FromResult(this.Query.Where(spec.SatisfyByCriteria()).AsEnumerable());
        }

        public MelhoresPraticas.CrossCutting.Transaction.IDbTransaction CreateTransaction()
        {
            return new MelhoresPraticas.CrossCutting.Transaction.DbTransaction(this.Context.Database.BeginTransaction());
        }

        public void Commit()
        {
            
        }

        public void Rollback()
        {
            
        }

        public MelhoresPraticas.CrossCutting.Transaction.IDbTransaction CreateTransaction(System.Data.IsolationLevel isolationLevel)
        {
            return new MelhoresPraticas.CrossCutting.Transaction.DbTransaction(this.Context.Database.BeginTransaction(isolationLevel));
        }
    }
}
