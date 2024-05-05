using LanguageLearningAPI.Application.Abstraction.Repositories;
using LanguageLearningAPI.Application.Abstraction.Services;
using LanguageLearningAPI.Application.Mapping;
using LanguageLearningAPI.Persistence.Concretes.Repositories;
using LanguageLearningAPI.Persistence.Concretes.Services;
using LanguageLearningAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<LanguageLearningDbContext>(options=>options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ILessonReadRepository,LessonReadRepository>();
            services.AddScoped<ILessonWriteRepository, LessonWriteRepository>();

            services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();
            services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository>();

            services.AddScoped<ILanguageService,LanguageService>();
            services.AddScoped<ILessonService,LessonService>();

            services.AddAutoMapper(typeof(MappingProfile));
        } 
    }
}
