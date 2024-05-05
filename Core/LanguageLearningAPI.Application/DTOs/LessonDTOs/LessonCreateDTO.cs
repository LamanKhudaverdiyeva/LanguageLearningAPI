using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Application.DTOs.LessonDTOs
{
    public class LessonCreateDTO
    {
       public string Title {  get; set; }
       public string Content { get; set; }
        public string Difficulty { get; set; }

       public int LanguageId { get; set; }
    }
}
