using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace UnderTheBrand.Domain.Core.Interfaces
{
    public interface IEntityRepository<TEntity> : IDisposable where TEntity : IHasId
    {
        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IReadOnlyCollection<TEntity>> AddRangeAsync([NotNull] IReadOnlyCollection<TEntity> entity);

        /// <summary>
        /// Получить сущность по id
        /// </summary>
        /// <returns></returns>
        TEntity GetById(TEntity entity);

        /// <summary>
        /// Получить сущность по id
        /// </summary>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TEntity entity);

        /// <summary>
        /// Получить все элементы
        /// </summary>
        /// <returns></returns>>
        IReadOnlyCollection<TEntity> GetAll();

        /// <summary>
        /// Получить все элементы
        /// </summary>
        /// <returns></returns>>
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Remove(TEntity entity);

        int SaveChanges();
    }
}
