using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> 
         where TEntity : class, IEntities, new()
         where TContext : DbContext, new()
    {
    public TEntity Add(TEntity entity)
        {
            //IDisposable pattern
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return entity;

                //var addedEntity = context.Entry(entity);
                //addedEntity.State = EntityState.Added;
                //context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();

                //var deletedEntity = context.Entry(entity);
                //deletedEntity.State = EntityState.Deleted;
                //context.SaveChanges();
            }
        }

     

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
                //var updatedEntity = context.Entry(entity);
                //updatedEntity.State = EntityState.Modified;
                //context.SaveChanges();
            }
        }
    }
}