using Microsoft.EntityFrameworkCore;
using Movie.Database.Context;
using Movie.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Database.Repositories
{
    public class BaseRepository<T>(MovieDatabaseContext databaseContext) where T : BaseEntity
    {
        protected DbSet<T> _dbSet { get; }=databaseContext.Set<T>();

        public Task<List<T>> GetAllAsync(bool includeDeletedEntities=false)
        {
           return GetRecords(includeDeletedEntities).ToListAsync();
        }

        public Task<T?> GetFirstOrDefaultAsync(int primaryKey, bool includeDeletedEntities = false)
        {
            var records=GetRecords(includeDeletedEntities);

            return records.FirstOrDefaultAsync(x => x.Id == primaryKey);
        }

        public void Insert(params T[] entities)
        {
            _dbSet.AddRange(entities);
        }


        public void Update(params T[] records)
        {
            foreach (var baseEntity in records)
            {
                baseEntity.UpdatedAt = DateTime.UtcNow;
            }

            _dbSet.UpdateRange(records);
        }

        public void SoftDelete(params T[] records)
        {
            foreach (var baseEntity in records)
            {
                baseEntity.DeletedAt = DateTime.UtcNow;
            }

            Update(records);
        }

        public Task SaveChangesAsync()
        {
            return databaseContext.SaveChangesAsync();
        }

        protected IQueryable<T> GetRecords(bool includeDeletedEntities = false)
        {
            var result = _dbSet.AsQueryable();

            if (includeDeletedEntities is false)
            {
                result = result.Where(r => r.DeletedAt == null);
            }

            return result;
        }

    }
}
