using LanguageLearningAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Application.Abstraction.Repositories
{
    public interface ILessonWriteRepository:IWriteRepository<Lesson>
    {
    }
}
