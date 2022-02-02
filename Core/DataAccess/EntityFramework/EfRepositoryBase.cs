using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
   public class EfRepositoryBase<TEntity, Context> :IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
       where Context :DbContext, new()
    {

        public void Add(TEntity entity)
        {
            using (Context context = new Context())
            {
                var addedCar = context.Entry(entity);
                addedCar.State = EntityState.Added;
                context.SaveChanges();
            }
        }


        public void Delete(TEntity entity)
        {
            using (Context context = new Context())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (Context context = new Context())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (Context context = new Context())
            {
                var updateCar = context.Entry(entity);
                updateCar.State = EntityState.Modified;
                context.SaveChanges();
            }


        }

    }
}
