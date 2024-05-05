using AutoMapper;
using LanguageLearningAPI.Application.Abstraction.Repositories;
using LanguageLearningAPI.Application.Abstraction.Services;
using LanguageLearningAPI.Application.DTOs.LanguageDTOs;
using LanguageLearningAPI.Application.Models;
using LanguageLearningAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Persistence.Concretes.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IMapper _mapper;
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ILanguageWriteRepository _languageWriteRepository;

        public LanguageService(IMapper mapper, ILanguageReadRepository languageReadRepository, ILanguageWriteRepository languageWriteRepository)
        {
                _mapper= mapper;
            _languageReadRepository= languageReadRepository;
            _languageWriteRepository= languageWriteRepository;
        }
        public async Task<ResponseModel<LanguageCreateDTO>> AddLanguage(LanguageCreateDTO dto)
        {
            try
            {
                if (dto != null)
                {
                    await _languageWriteRepository.AddAsync(new()
                    {
                       Name = dto.Name,
                       Level= dto.Level                     

                    });
                    var affectedRows = await _languageWriteRepository.SaveAsync();
                    if (affectedRows > 0)
                    {
                        return new ResponseModel<LanguageCreateDTO>
                        {
                            Data = dto,
                            StatusCode = 201
                        };
                    }
                    else
                    {
                        return new ResponseModel<LanguageCreateDTO>
                        {
                            Data = null,
                            StatusCode = 500
                        };
                    }
                }
                else
                {
                    return new ResponseModel<LanguageCreateDTO>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<LanguageCreateDTO>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }


        public async Task<ResponseModel<bool>> DeleteLanguage(int id)
        {
            try
            {
                Language language = await _languageReadRepository.GetByIdAsync(id);
                if (language != null)
                {
                    _languageWriteRepository.Remove(language);

                    var affectedRows = await _languageWriteRepository.SaveAsync();

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


        public async Task<ResponseModel<List<LanguageGetDTO>>> GetAllLanguages()
        {
            try
            {
                List<Language> languageList = await _languageReadRepository.GetAll().ToListAsync();

                if (languageList.Count > 0)
                {
                    List<LanguageGetDTO> languages = _mapper.Map<List<LanguageGetDTO>>(languageList);
                    return new ResponseModel<List<LanguageGetDTO>>
                    {
                        Data = languages,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseModel<List<LanguageGetDTO>>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<List<LanguageGetDTO>>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<LanguageGetDTO>> GetLanguagesById(int id)
        {
            try
            {
                Language language = await _languageReadRepository.GetByIdAsync(id);
                if (language != null)
                {
                    LanguageGetDTO languageDTO = _mapper.Map<LanguageGetDTO>(language);
                    return new ResponseModel<LanguageGetDTO>
                    {
                        Data = languageDTO,
                        StatusCode = 200
                    };
                }
                else
                {
                    return new ResponseModel<LanguageGetDTO>
                    {
                        Data = null,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<LanguageGetDTO>
                {
                    Data = null,
                    StatusCode = 500
                };
            }
        }

        public async Task<ResponseModel<LanguageUpdateDTO>> UpdateLanguages(LanguageUpdateDTO dto)
        {
            try
            {
                if (dto != null)
                {
                    Language language = await _languageReadRepository.GetByIdAsync(dto.Id);
                    if (language != null)
                    {
                        language.Name = dto.Name;
                        language.Level = dto.Name;

                        _languageWriteRepository.Update(language);
                        var affectedRows = await _languageWriteRepository.SaveAsync();

                        if (affectedRows > 0)
                        {
                            return new ResponseModel<LanguageUpdateDTO>
                            {
                                Data = dto,
                                StatusCode = 200
                            };
                        }
                        else
                        {
                            return new ResponseModel<LanguageUpdateDTO>
                            {
                                Data = null,
                                StatusCode = 500
                            };
                        }
                    }
                    else
                    {
                        return new ResponseModel<LanguageUpdateDTO>
                        {
                            Data = null,
                            StatusCode = 400
                        };
                    }
                }
                else
                {
                    return new ResponseModel<LanguageUpdateDTO>
                    {
                        Data = dto,
                        StatusCode = 400
                    };
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + ex.InnerException);

                return new ResponseModel<LanguageUpdateDTO>
                {
                    Data = dto,
                    StatusCode = 500
                };
            }
        }
    }
}
