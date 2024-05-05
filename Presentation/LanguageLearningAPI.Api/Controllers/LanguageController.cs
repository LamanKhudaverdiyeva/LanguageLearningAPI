using LanguageLearningAPI.Application.Abstraction.Repositories;
using LanguageLearningAPI.Application.Abstraction.Services;
using LanguageLearningAPI.Application.DTOs.LanguageDTOs;
using LanguageLearningAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearningAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {

        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService) 
        { 
          _languageService = languageService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLanguages()
        {
            var data = await _languageService.GetAllLanguages();
            return StatusCode(data.StatusCode, data);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetLanguageById(int id)
        {
            var data = await _languageService.GetLanguagesById(id);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddLsnguage(LanguageCreateDTO languageCreateDTO)
        {
            var data = await _languageService.AddLanguage(languageCreateDTO);
            return StatusCode(data.StatusCode, data);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteLanguage(int Id)
        {
            var data = await _languageService.DeleteLanguage(Id);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateLanguage(LanguageUpdateDTO languageUpdateDTO)
        {
            var data = await _languageService.UpdateLanguages(languageUpdateDTO);
            return StatusCode(data.StatusCode, data);
        }
    }
}
