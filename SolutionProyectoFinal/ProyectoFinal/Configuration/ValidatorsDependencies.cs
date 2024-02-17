﻿using FluentValidation;
using ProyectoFinal.Validations;
using static ProyectoFinal.DTOs.UsuarioDTO;

namespace ProyectoFinal.Configuration
{
    public static class ValidatorsDependencies
    {
        public static void ValidatorsInjections(this IServiceCollection services)
        {
            //User
            services.AddScoped<IValidator<RegisterUserRequestDto>, RegisterUserValidator>();
            services.AddScoped<IValidator<LoginUserRequestDto>, LoginUserValidator>();
            services.AddScoped<IValidator<UpdateUserRequestDto>, UpdateUserValidator>();
            services.AddScoped<IValidator<DeleteUserRequestDto>, DeleteUserValidator>();
        }
    }
}
