using AutoMapper;
using LanguageLearningAPI.Application.Abstraction.Repositories;
using LanguageLearningAPI.Application.Abstraction.Services;
using LanguageLearningAPI.Application.DTOs.LanguageDTOs;
using LanguageLearningAPI.Application.DTOs.LessonDTOs;
using LanguageLearningAPI.Application.Models;
using LanguageLearningAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Persistence.Concretes.Services
{
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly ILessonReadRepository _lessonReadRepository;
        private readonly ILessonWriteRepository _lessonWriteRepository;
        public LessonService(IMapper mapper,  ILessonWriteRepository lessonWriteRepository, ILessonReadRepository lessonReadRepository)
        {
            _mapper=mapper;
            _lessonReadRepository = lessonReadRepository;
            _lessonWriteRepository = lessonWriteRepository;
        }
        public async Task<ResponseModel<LessonCreateDTO>> AddLesson(LessonCreateDTO dto)
        {
            try
            {
                if (dto != null)
                {
                    await _lessonWriteRepository.AddAsync(new()
                    {
                        Title= dto.Title,
                        Difficulty= dto.Difficulty,
                        Content= dto.Content,
                        LanguageId=dto.LanguageId

                    });
                    var affectedRows = await _lessonWriteRepository.SaveAsync();
                    if (affectedRows > 0)
                    {
                        return new ResponseModel<LessonCreateDTO>
                        {
                            Data = dto,
                            StatusCode = 201
                        };
                    }
                    else
                    {
                        return new ResponseModel<LessonCreateDTO>
                        {
                            Data = null,
                            StatusCode = 500
                        };
                    }
                }
                else
                {
                    return new ResponseModel<LessonCreateDTO>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<LessonCreateDTO>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }


        public async Task<ResponseModel<bool>> DeleteLesson(int id)
        {
            try
            {
                Lesson lesson = await _lessonReadRepository.GetByIdAsync(id);
                if (lesson != null)
                {
                    _lessonWriteRepository.Remove(lesson);

                    var affectedRows = await _lessonWriteRepository.SaveAsync();

                    if (affectedRows > 0)
                    {
                        return new ResponseModel<bool>
                        {
                            Data = true,
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new ResponseModel<bool>
                        {
                            Data = false,
                            StatusCode = 500
                        };
                    }
                }
                else
                {
                    return new ResponseModel<bool>
                    {
                        Data = false,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<bool>
                {
                    Data = false,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<List<LessonGetDTO>>> GetAllLessons()
        {
            try
            {
                List<Lesson> lessonList = await _lessonReadRepository.GetAll()
                                        .Include(x => x.Language).ToListAsync();

                if (lessonList.Count > 0)
                {
                    List<LessonGetDTO> lessons = _mapper.Map<List<LessonGetDTO>>(lessonList);
                    return new ResponseModel<List<LessonGetDTO>>
                    {
                        Data = lessons,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseModel<List<LessonGetDTO>>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<List<LessonGetDTO>>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }


        public async Task<ResponseModel<List<LessonGetDTO>>> GetAllLessonsByLanguageId(int LanguageId)
        {
            try
            {
                var lessons = await _lessonReadRepository.GetAll().Where(s => s.LanguageId == LanguageId).ToListAsync();
                if (lessons != null)
                {
                    var lessonDTO = _mapper.Map<List<LessonGetDTO>>(lessons);
                    return new ResponseModel<List<LessonGetDTO>>
                    {
                        Data = lessonDTO,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseModel<List<LessonGetDTO>>
                    {
                        Data = null,
                        StatusCode = 404
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);
                return new ResponseModel<List<LessonGetDTO>> { Data = null, StatusCode = 500 };
            }
        }
        public async Task<ResponseModel<LessonGetDTO>> GetLessonsById(int id)
        {
            try
            {

                Lesson lesson = await _lessonReadRepository.GetByIdAsync(id);
                if (lesson != null)
                {
                    await _lessonReadRepository.GetByIdAsync(lesson.LanguageId);
                    LessonGetDTO lessonGetDTO = _mapper.Map<LessonGetDTO>(lesson);
                    return new ResponseModel<LessonGetDTO>
                    {
                        Data = lessonGetDTO,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseModel<LessonGetDTO>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<LessonGetDTO>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<bool>> UpdateLesson(LessonUpdateDTO dto, int id)
        {
            try
            {
                if (dto != null)
                {
                    Lesson lesson = await _lessonReadRepository.GetByIdAsync(id);

                    if (lesson != null)
                    {
                        lesson.Title=dto.Title;
                        lesson.Content = dto.Content;
                        lesson.Difficulty = dto.Difficulty;

                        _lessonWriteRepository.Update(lesson);
                        var affectedRows = await _lessonWriteRepository.SaveAsync();

                        if (affectedRows > 0)
                        {
                            return new ResponseModel<bool>
                            {
                                Data = true,
                                StatusCode = 200
                            };
                        }
                        else
                        {
                            return new ResponseModel<bool>
                            {
                                Data = false,
                                StatusCode = 500
                            };
                        }
                    }
                    else
                    {
                        return new ResponseModel<bool>
                        {
                            Data = false,
                            StatusCode = 400
                        };
                    }
                }
                else
                {
                    return new ResponseModel<bool>
                    {
                        Data = false,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<bool>
                {
                    Data = false,
                    StatusCode = 500
                };
            }
        }

    }
}
//