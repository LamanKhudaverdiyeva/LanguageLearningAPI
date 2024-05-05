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
    public class LanguageWriteRepository : WriteRepository<Language>, ILanguageWriteRepository
    {
        public LanguageWriteRepository(LanguageLearningDbContext context) : base(context)
        {
        }
    }
}
