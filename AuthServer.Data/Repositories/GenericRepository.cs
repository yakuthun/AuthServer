using AuthServer.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data.Repositories
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class
    {
        private readonly DbContext _context;//veritabanı işlemleri için DbContext'e ihtiyaç var
        private readonly DbSet<Tentity> _dbSet;//tablolar üzerinde işlem yapabilmemiz için DbSet ekleyelim.
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Tentity>(); //Set dbset'e karşılık gelir.
        }
        public async Task AddAsync(Tentity entity)
        {
            await _dbSet.AddAsync(entity);
            //saveChanges çağırmıyoruz. Service katmanında yapacağız.
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            //EntityState.Detached yapısını service class'ını anlatırken detaylandırılacak.
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;//takip edilmesin track edilmesin
            }
            return entity;
        }

        public void Remove(Tentity entity)
        {
            _dbSet.Remove(entity);
        }

        public Tentity Update(Tentity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<Tentity> Where(Expression<Func<Tentity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
