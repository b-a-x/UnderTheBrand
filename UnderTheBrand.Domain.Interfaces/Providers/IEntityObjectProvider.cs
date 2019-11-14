﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UnderTheBrand.Domain.Core.Base;

namespace UnderTheBrand.Domain.Interfaces.Providers
{
    /// <summary>
    /// Базовый интерфей CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityObjectProvider<T> where T : Entity
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
