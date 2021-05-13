using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infra.Context;

namespace Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> GetAll()
        {
            var query = _context.Set<T>();

            if (query.Any())
                return query.ToList();

            return new List<T>();
        }

        public virtual T GetById(int id)
        {
            var query = _context.Set<T>().Where(e => e.Id == id);

            if (query.Any())
                return query.FirstOrDefault();

            return null;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}