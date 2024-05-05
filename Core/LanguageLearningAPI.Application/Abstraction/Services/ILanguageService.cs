using LanguageLearningAPI.Application.DTOs.LanguageDTOs;
using LanguageLearningAPI.Application.DTOs.LessonDTOs;
using LanguageLearningAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Application.Abstraction.Services
{
    public interface ILanguageService
    {
        Task<ResponseModel<LanguageCreateDTO>> AddLanguage(LanguageCreateDTO dto);
        Task<ResponseModel<bool>> DeleteLanguage(int id);
        Task<ResponseModel<LanguageUpdateDTO>> UpdateLanguages(LanguageUpdateDTO dto);
        Task<ResponseModel<List<LanguageGetDTO>>> GetAllLanguages();
        Task<ResponseModel<LanguageGetDTO>> GetLanguagesById(int id);

    }
}
