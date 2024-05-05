using AutoMapper;
using LanguageLearningAPI.Application.DTOs.LanguageDTOs;
using LanguageLearningAPI.Application.DTOs.LessonDTOs;
using LanguageLearningAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Application.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {

            CreateMap<Lesson, LessonGetDTO>().ReverseMap();

            CreateMap<Language, LanguageGetDTO>().ReverseMap();
        }
    }
}
