using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Migrations;
using Cinema.DTO.InnerModels;

namespace Cinema.Domain.Implementations
{
    public class ModelRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly CinemaDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public ModelRepository(CinemaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item));
            }
            _context.Add(item);
        }

        public void CreateRange(IEnumerable<TEntity> items)
        {
            if (items == null)
            {
                throw new ArgumentException(nameof(items));
            }
            _context.AddRange(items);
        }

        public void CreateOrUpdate(TEntity item, Func<TEntity, bool> predicate)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));    
            }

            var dbEntity = Get(predicate).FirstOrDefault();
            if (dbEntity != null)
            {
                Update(item);
            }
            else
            {
                Create(item);
            }
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            if (predicate == default)
            {
                throw new ArgumentException(nameof(predicate));
            }
            
            return _dbSet.ToList().Where(e => predicate(e));
        }

        public void Remove(TEntity item)
        {
            if (item == default)
            {
                throw new ArgumentException(nameof(item));
            }

            _context.Remove(item);
        }

        public void Update(TEntity item)
        {
            if (item == default)
            {
                throw new ArgumentException(nameof(item));
            }
            
            _context.Update(item);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}