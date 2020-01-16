﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PommaLabs.Thrower;
using UnderTheBrand.Domain.Entity.Base;
using UnderTheBrand.Domain.Interfaces.Repositories;
using UnderTheBrand.Infrastructure.Dal.Context;

namespace UnderTheBrand.Infrastructure.Dal.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : Entity
    {
        protected readonly UnderTheBrandContext _context;
        protected EntityRepository() { }

        public EntityRepository(UnderTheBrandContext context)
        {
            Raise.ArgumentNullException.IfIsNull(context, nameof(context));
            
            _context = context;
        }
        
        public T Create(T entity)
        {
            Raise.ArgumentNullException.IfIsNull(entity, nameof(entity));
            entity.Id = new Guid();
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            _context.Set<T>().Add(entity);
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            Raise.ArgumentNullException.IfIsNull(entity, nameof(entity));
            entity.Id = new Guid();
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            await _context.Set<T>().AddAsync(entity);
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<T>> CreateRangeAsync(IReadOnlyCollection<T> entity)
        {
            Raise.ArgumentNullException.IfIsNull(entity, nameof(entity));
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            await _context.Set<T>().AddRangeAsync(entity);
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            await _context.SaveChangesAsync();
            return entity;
        }

        public IReadOnlyCollection<T> Read() => _context.Set<T>().AsNoTracking().ToList();

        public async Task<IReadOnlyCollection<T>> ReadAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public T Update(T entity)
        {
            Raise.ArgumentNullException.IfIsNull(entity, nameof(entity));

            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Raise.ArgumentNullException.IfIsNull(entity, nameof(entity));

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool Delete(T entity)
        {
            Raise.ArgumentNullException.IfIsNull(entity, nameof(entity));

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            Raise.ArgumentNullException.IfIsNull(entity, nameof(entity));

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
