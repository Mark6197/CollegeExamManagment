﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetAsync(long? id);
        bool IsExist(long? id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetEntityWithEagerLoadAsync(Expression<Func<TEntity, bool>> filter, string[] children);
    }
}
