using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace AspCoreSkeletonZien.Core
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected readonly TContext context;
        protected DbSet<TEntity> entities;
        protected virtual DbSet<TEntity> Entities { get => entities; set => entities = value; }

        public Repository(TContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }
        /** Create **/
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            int result = await context.SaveChangesAsync();
            return result > 0 ? entity : null;
        }

        /** Read **/
        public virtual async Task<TEntity> GetByIdAsync(params object[] id)
        {
            TEntity result = await entities.FindAsync(id);
            return result;
        }
        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        ////Each entity should override this and include its navigation properties with .include()
        //public virtual Task<PaginatedList<TEntity>> GetPagedAsync(int pageNumber, int pageSize = 9)
        //{
        //    return PaginatedList<TEntity>.Create(entities, pageNumber, pageSize);
        //}

        /** Update **/
        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null) return false;
            entities.Update(entity);
            int success = await context.SaveChangesAsync();
            return success > 0;
        }


        /** Delete **/
        public virtual async Task<bool> RemoveAsync(TEntity entity)
        {
            if (entity == null) return false;
            entities.Remove(entity);
            int success = await context.SaveChangesAsync();
            return success > 0;
        }

        public virtual async Task<bool> RemoveByIdAsync(params object[] id)
        {
            TEntity result = await entities.FindAsync(id);
            if (result == null) return false;
            entities.Remove(result);
            int success = await context.SaveChangesAsync();
            return success > 0;
        }

    }
}
