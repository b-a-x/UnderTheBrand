using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnderTheBrand.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Базовый интерфей CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T : Entity.Base.Entity
    {
        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Create(T entity);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Прочитать
        /// </summary>
        /// <returns></returns>
        IReadOnlyCollection<T> Read();

        /// <summary>
        /// Прочитать
        /// </summary>
        /// <returns></returns>>
        Task<IReadOnlyCollection<T>> ReadAsync();

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T entity);
    }
}
