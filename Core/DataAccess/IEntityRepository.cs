using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity>
    {
        TEntity Add(TEntity entity);

      
        TEntity Get(Expression<Func<TEntity, bool>> filter);

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);


      

        void Update(TEntity entity);



        void Delete(TEntity entity);

     
    }
}