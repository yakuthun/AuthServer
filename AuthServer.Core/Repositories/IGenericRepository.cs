using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {//create, update, delete, list gibi işlemleri yapacaız
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Where(Expression<Func<TEntity,bool>> predicate);
        //product = productRepository.Where(x=>x.id>5);
        //product.any
        //product.ToList deyince bütün sorgularak yansır.

        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
        //_context.Entry(entity).state=EntityState.Modified
    }
}
