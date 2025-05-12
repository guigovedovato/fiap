﻿using FCG.Domain.Common;

namespace FCG.Infrastructure.Data.Repository;

public interface IRepository<T> where T : EntityBase
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
