using HorasExtras.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Infrastructure.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection InyectarBaseDeDatos(this IServiceCollection svc, IConfiguration configuration)
        {
            var sqlServerConecction = configuration.GetConnectionString("database");
            int timeOut = 60;
            svc.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlServer(sqlServerConecction, sqlOpts =>
                {
                    sqlOpts.CommandTimeout(timeOut).EnableRetryOnFailure();
                });
                opt.EnableSensitiveDataLogging();
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);

            return svc;
        }
    }
}
