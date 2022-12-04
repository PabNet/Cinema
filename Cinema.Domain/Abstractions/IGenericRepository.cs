using System;
using System.Collections.Generic;

namespace Cinema.Domain.Abstractions
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        void CreateRange(IEnumerable<TEntity> items);
        void CreateOrUpdate(TEntity item, Func<TEntity, bool> predicate);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}