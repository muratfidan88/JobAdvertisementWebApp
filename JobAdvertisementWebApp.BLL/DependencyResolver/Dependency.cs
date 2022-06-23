using AutoMapper;
using FluentValidation;
using JobAdvertisementWebApp.BLL.Interfaces;
using JobAdvertisementWebApp.BLL.Mapping.AutoMapper.Profiles;
using JobAdvertisementWebApp.BLL.Services;
using JobAdvertisementWebApp.BLL.ValidationRules.AdvertisementValidationRules;
using JobAdvertisementWebApp.BLL.ValidationRules.ApplicationValidationRules;
using JobAdvertisementWebApp.BLL.ValidationRules.AppUserDtoValidationRules;
using JobAdvertisementWebApp.BLL.ValidationRules.CompanyValidationRules;
using JobAdvertisementWebApp.BLL.ValidationRules.MemberCvValidationRules;
using JobAdvertisementWebApp.DAL.Data.Contexts;
using JobAdvertisementWebApp.DAL.Interfaces;
using JobAdvertisementWebApp.DAL.Repositories;
using JobAdvertisementWebApp.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JobAdvertisementWebApp.BLL.DependencyResolver
{
    public static class Dependency
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<JobAdvertisementContext>(opt =>
            {
                opt.UseSqlServer("server=DESKTOP-BA2PLFB; database=JobAdvertisementDB;" +
                "integrated security=true;");
            });

            var mapperConfiguration = new MapperConfiguration(opt =>
            {
               opt.AddProfile(new AppUserProfile());
               opt.AddProfile(new MemberCvProfile());
               opt.AddProfile(new CompanyProfile());
               opt.AddProfile(new AdvertisementProfile());
               opt.AddProfile(new ApplicationProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();

            services.AddTransient<IValidator<MemberCvCreateDto>, MemberCvCreateDtoValidator>();
            services.AddTransient<IValidator<MemberCvUpdateDto>, MemberCvUpdateDtoValidator>();

            services.AddTransient<IValidator<CompanyCreateDto>, CompanyCreateDtoValidator>();
            services.AddTransient<IValidator<CompanyUpdateDto>, CompanyUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();

            services.AddTransient<IValidator<ApplicationCreateDto>, ApplicationCreateDtoValidator>();
            services.AddTransient<IValidator<ApplicationUpdateDto>, ApplicationUpdateDtoValidator>();

            services.AddSingleton(mapper);
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IMemberCvService, MemberCvService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
