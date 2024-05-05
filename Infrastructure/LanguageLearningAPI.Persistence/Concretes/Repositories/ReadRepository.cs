using LanguageLearningAPI.Application.Abstraction.Repositories;
using LanguageLearningAPI.Domain.Entities.Common;
using LanguageLearningAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LanguageLearningAPI.Persistence.Concretes.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly LanguageLearningDbContext _context;
        public ReadRepository(LanguageLearningDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
           => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
           => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
           => await Table.FirstOrDefaultAsync(method);

        public async Task<T> GetByIdAsync(int id)
         /*   => await Table.FirstOrDefaultAsync(data => data.Id == id);*/
         =>await Table.FindAsync(id);



    }
}
