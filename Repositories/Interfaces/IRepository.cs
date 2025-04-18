﻿using System.Linq.Expressions;

namespace PrimeiraAPI.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        // CRUD
        IEnumerable<T> GetAll();
        T? Get(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}
