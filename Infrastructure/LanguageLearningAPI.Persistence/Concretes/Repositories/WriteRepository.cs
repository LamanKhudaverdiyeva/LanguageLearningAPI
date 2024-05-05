using LanguageLearningAPI.Application.Abstraction.Repositories;
using LanguageLearningAPI.Domain.Entities.Common;
using LanguageLearningAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Persistence.Concretes.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly LanguageLearningDbContext _context;
        public WriteRepository(LanguageLearningDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
           EntityEntry<T> entityEntry= await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
           await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
          EntityEntry<T>entityEntry= Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
          T model=  await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(model);

        }
        public bool RemoveRange(List<T> datas)
        {
           Table.RemoveRange(datas);
            return true;
        }
        public bool Update(T model)
        {
          EntityEntry entity= Table.Update(model); 
            return entity.State==EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

    }

}
