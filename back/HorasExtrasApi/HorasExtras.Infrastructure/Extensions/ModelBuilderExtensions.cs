using HorasExtras.Domain.Entities;
using HorasExtras.Infrastructure.Context;
using HorasExtras.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HorasExtras.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ShadowProperties(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var t = entityType.ClrType;
                if (typeof(EntityBase<>).IsAssignableFrom(t))
                {
                    var method = SetAuditingShadowPropertiesMethodInfo.MakeGenericMethod(t);
                    method.Invoke(modelBuilder, new object[] { modelBuilder });
                }
            }
        }

        private static readonly MethodInfo SetAuditingShadowPropertiesMethodInfo = typeof(ModelBuilderExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
    .Single(t => t.IsGenericMethod && t.Name == "SetAuditingShadowProperties");

        public static void SetAuditingShadowProperties<T>(ModelBuilder builder) where T : EntityBase<T>
        {
            // define shadow properties
            builder.Entity<T>().Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
            builder.Entity<T>().Property<DateTime>("LastModifiedOn").HasDefaultValueSql("GETDATE()");

        }

        public static void SeedDataBase(this IServiceProvider service)
        {
            using (var serviceScope = service.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();
                var roles = UsuarioSeed.ObtenerRoles();
                if (context != null && !context.Set<Rol>().Any())
                {
                    context.Set<Rol>().AddRange(
                        roles
                    );
                    context.SaveChanges();
                }
                if (context != null && !context.Set<Usuario>().Any())
                {
                    context.Set<Usuario>().AddRange(
                        UsuarioSeed.ObtenerUsuariosSeed(roles)
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
