using LanguageLearningAPI.Application.DTOs.LessonDTOs;
using LanguageLearningAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Application.Abstraction.Services
{
    public interface ILessonService
    {
         Task<ResponseModel<LessonCreateDTO>> AddLesson(LessonCreateDTO dto);
        Task<ResponseModel<bool>> DeleteLesson(int id);
        Task<ResponseModel<bool>>UpdateLesson(LessonUpdateDTO dto, int id);
        Task<ResponseModel<List<LessonGetDTO>>> GetAllLessons();
        Task<ResponseModel<LessonGetDTO>> GetLessonsById(int id);

        Task<ResponseModel<List<LessonGetDTO>>> GetAllLessonsByLanguageId(int LanguageId);


    }
}
