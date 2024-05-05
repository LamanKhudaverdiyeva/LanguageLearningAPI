using LanguageLearningAPI.Application.Abstraction.Repositories;
using LanguageLearningAPI.Domain.Entities;
using LanguageLearningAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Persistence.Concretes.Repositories
{
    public class LanguageReadRepository : ReadRepository<Language>, ILanguageReadRepository
    {
        public LanguageReadRepository(LanguageLearningDbContext context) : base(context)
        {
        }
    }
}
