using HorasExtras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorasExtras.Infrastructure.Context.Configs
{
    public class SolicitudHorasExtrasConfig : IEntityTypeConfiguration<SolicitudHorasExtras>
    {
        public void Configure(EntityTypeBuilder<SolicitudHorasExtras> builder)
        {
            builder.HasKey(solicitud=> solicitud.Id);
            builder.Property(solicitud => solicitud.Motivo).HasMaxLength(500);
        }
    }
}
