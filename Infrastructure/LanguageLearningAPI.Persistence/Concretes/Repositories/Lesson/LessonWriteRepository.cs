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
    public class LessonWriteRepository : WriteRepository<Lesson>, ILessonWriteRepository
    {
        public LessonWriteRepository(LanguageLearningDbContext context) : base(context)
        {
        }
    }
}
