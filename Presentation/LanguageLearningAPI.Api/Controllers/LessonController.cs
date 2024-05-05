using LanguageLearningAPI.Application.Abstraction.Services;
using LanguageLearningAPI.Application.DTOs.LessonDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LanguageLearningAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;
        public LessonController(ILessonService service)
        {
            _service = service;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLesson()
        {
            var data = await _service.GetAllLessons();
            return StatusCode(data.StatusCode, data);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetLessonByID(int id)
        {
            var data = await _service.GetLessonsById(id);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddLesson(LessonCreateDTO dto)
        {
            var data = await _service.AddLesson(dto);
            return StatusCode(data.StatusCode, data);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var data = await _service.DeleteLesson(id);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateLesson(LessonUpdateDTO dto, int id)
        {
            var data = await _service.UpdateLesson(dto, id);
            return StatusCode(data.StatusCode, data);
        }
        [HttpGet("[action]/{languageID}")]
        public async Task<IActionResult> GetAllLessonByLanguageId(int languageID)
        {
            var data = await _service.GetAllLessonsByLanguageId(languageID);
            return StatusCode(data.StatusCode, data);
        }

    }
}
