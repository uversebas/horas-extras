using HorasExtras.Domain.Entities;
using HorasExtras.Infrastructure.Context.Configs;
using HorasExtras.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HorasExtras.Infrastructure.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Colaborador>();
            builder.Entity<Area>();
            builder.Entity<Usuario>();
            builder.Entity<Rol>();            
            builder.Entity<SolicitudHorasExtras>();
            builder.Entity<AprobacionHorasExtras>();
            builder.ApplyConfiguration(new ColaboradorConfig());
            builder.ApplyConfiguration(new AreaConfig());
            builder.ApplyConfiguration(new SolicitudHorasExtrasConfig());
            builder.ApplyConfiguration(new AprobacionHorasExtrasConfig());
            builder.ShadowProperties();

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var t = entityType.ClrType;
                if (typeof(EntityBase<>).IsAssignableFrom(t))
                {
                    builder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
                    builder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn").HasDefaultValueSql("GETDATE()");
                }
            }

            base.OnModelCreating(builder);
        }
    }
}
