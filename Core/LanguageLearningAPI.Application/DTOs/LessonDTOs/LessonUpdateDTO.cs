using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Application.DTOs.LessonDTOs
{
    public class LessonUpdateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Difficulty { get; set; }
    }
}
