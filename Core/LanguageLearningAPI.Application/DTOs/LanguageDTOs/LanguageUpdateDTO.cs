using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Application.DTOs.LanguageDTOs
{
    public class LanguageUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
    }
}
