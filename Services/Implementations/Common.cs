using ASPWebApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPWebApp.Services.Implementations
{
    public class CommonService<T> where T : class
    {
        protected readonly BaseInterface<T> _repo;

        public CommonService(BaseInterface<T> repo)
        {
            _repo = repo;
        }

        public List<T> GetAll() => _repo.GetAll().ToList();
        public T? GetById(int id) => _repo.GetById(id);
        public void Create(T entity) => _repo.Create(entity);
        public void Update(T entity) => _repo.Update(entity);
        public void Delete(T entity) => _repo.Delete(entity);
        public bool Any(Func<T, bool> predicate) => _repo.Any(predicate);
    }
}