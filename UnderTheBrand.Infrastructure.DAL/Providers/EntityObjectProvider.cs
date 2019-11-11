using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core.Base;
using UnderTheBrand.Domain.Interfaces.Providers;
using UnderTheBrand.Infrastructure.DAL.Context;

namespace UnderTheBrand.Infrastructure.DAL.Providers
{
    public class EntityObjectProvider<T> : IEntityObjectProvider<T> where T : EntityObject
    {
        protected readonly UnderTheBrandContext Context;
        protected EntityObjectProvider() { }

        public EntityObjectProvider(UnderTheBrandContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public T Create(T entity)
        {
            if (entity == null) throw new ArgumentException(nameof(entity));

             Context.Set<T>().Add(entity);
             Context.SaveChanges();
             return entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null) throw new ArgumentException(nameof(entity));

            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public IReadOnlyCollection<T> Read() => Context.Set<T>().ToList();

        public async Task<IReadOnlyCollection<T>> ReadAsync() => await Context.Set<T>().ToListAsync();

        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentException(nameof(entity));

            Context.Set<T>().Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentException(nameof(entity));

            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public bool Delete(T entity)
        {
            if (entity == null) throw new ArgumentException(nameof(entity));

            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentException(nameof(entity));

            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
