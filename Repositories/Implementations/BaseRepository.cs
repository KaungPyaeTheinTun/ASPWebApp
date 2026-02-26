using ASPWebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using ASPWebApp.Data;

namespace ASPWebApp.Repositories.Implementations
{
    public class BaseRepository<T> : BaseInterface<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll() => _dbSet.AsQueryable();

        public T? GetById(int id) => _dbSet.Find(id);

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public bool Any(Func<T, bool> predicate) => _dbSet.Any(predicate);
    }
}