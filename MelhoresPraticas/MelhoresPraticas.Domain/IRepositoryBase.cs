using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MelhoresPraticas.Domain
{
    public interface IRepositoryBase<T> : IUnitOfWork
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task Save(T obj);
        Task Update(object id, T obj);
        Task Delete(object id);
        Task<T> GetOneByCriteria(ISpecification<T> spec);
        Task<IEnumerable<T>> GetAllByCriteria(ISpecification<T> spec);


        
    }
}
