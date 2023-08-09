using HorasExtras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HorasExtras.Infrastructure.Context.Configs
{
    public class AprobacionHorasExtrasConfig : IEntityTypeConfiguration<AprobacionHorasExtras>
    {
        public void Configure(EntityTypeBuilder<AprobacionHorasExtras> builder)
        {
            builder.HasKey(aprobacion => aprobacion.Id);
            builder.Property(aprobacion => aprobacion.MotivoLider).HasMaxLength(500);
            builder.Property(aprobacion => aprobacion.MotivoRRHH).HasMaxLength(500);
            builder.HasOne(a => a.Lider)
               .WithMany()
               .HasForeignKey(a => a.LiderId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.AprobadorRRHH)
               .WithMany()
               .HasForeignKey(a => a.AprobadorRRHHId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
