using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSkeletonZien.Core
{

        public interface IRepository<TEntity>
        {
            Task<TEntity> GetByIdAsync(params object[] id);
            Task<ICollection<TEntity>> GetAllAsync();
            Task<TEntity> AddAsync(TEntity entity);
            Task<bool> UpdateAsync(TEntity entity);
            Task<bool> RemoveAsync(TEntity entity);
            Task<bool> RemoveByIdAsync(params object[] id);
            
            
            //Task<PaginatedList<TEntity>> GetPagedAsync(int pageNumber, int pageSize);

    }
}
