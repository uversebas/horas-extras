using HorasExtras.Infrastructure.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Infrastructure.Extensions
{
    public static class ConfigExtensions
    {
        public static IServiceCollection AgregarConfiguraciones(this IServiceCollection services, IConfiguration configuration)
        {

            var jwtConfig = new JwtConfig
            {
                KeyJwt = configuration["Jwt:Key"],
                Audience = configuration["Jwt:Audience"],
                Issuer = configuration["Jwt:Issuer"],
                Subject = configuration["Jwt:Subject"],
                DuracionEnMinutos = int.Parse(configuration["Jwt:DuracionEnMinutos"])   
            }; 
            services.AddSingleton(jwtConfig);
            return services;

        }
    }
}
