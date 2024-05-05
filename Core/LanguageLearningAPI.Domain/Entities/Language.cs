using LanguageLearningAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Domain.Entities
{
    public class Language: BaseEntity
    {
        public string Name {  get; set; }
        public string Level { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
