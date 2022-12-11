using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
      
        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public T Insert(T entity)
        {
            if (entity is null)
            {
                return entity;
            }
            var addedObj = entities.Add(entity);
            return addedObj.Entity;
        }

        public bool Remove(T entity)
        {
            if (entity is null)
            {
                return false;
            }
            entities.Remove(entity);
            return true;
        }
        public void Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
        }
    }
}
