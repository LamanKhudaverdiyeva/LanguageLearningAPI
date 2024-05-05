using LanguageLearningAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Domain.Entities
{
    public class Lesson:BaseEntity
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Difficulty { get; set; }
        public Language Language { get; set; }

    }
}
