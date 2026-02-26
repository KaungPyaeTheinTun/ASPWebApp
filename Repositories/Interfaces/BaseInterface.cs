using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPWebApp.Repositories.Interfaces
{
    public interface BaseInterface<T> where T : class
    {
        IQueryable<T> GetAll();
        T? GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Func<T, bool> predicate);
    }
}