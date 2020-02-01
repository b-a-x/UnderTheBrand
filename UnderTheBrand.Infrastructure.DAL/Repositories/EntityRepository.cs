using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnderTheBrand.Domain.Core.Interfaces;
using UnderTheBrand.Domain.Entity.Base;
using UnderTheBrand.Infrastructure.Dal.Context;

namespace UnderTheBrand.Infrastructure.Dal.Repositories
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : Entity
    {
        protected readonly UnderTheBrandContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected EntityRepository()
        {
            _context = new UnderTheBrandContext();
            _dbSet = _context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            _dbSet.Add(entity);
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            await _dbSet.AddAsync(entity);
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            return entity;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> AddRangeAsync([NotNull] IReadOnlyCollection<TEntity> entity)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            await _dbSet.AddRangeAsync(entity);
            _context.ChangeTracker.AutoDetectChangesEnabled = true;
            return entity;
        }

        public virtual TEntity GetById(TEntity hasId) => _dbSet.Find(hasId.Id);

        public virtual async Task<TEntity> GetByIdAsync(TEntity hasId) => await _dbSet.FindAsync(hasId.Id);

        public virtual IReadOnlyCollection<TEntity> GetAll() => _dbSet.AsNoTracking().ToList();

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

        public virtual TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public virtual void Remove(TEntity entity) => _dbSet.Remove(entity: _dbSet.Find(entity.Id));
        
        public int SaveChanges() =>_context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(obj: this);
        }
    }
}
