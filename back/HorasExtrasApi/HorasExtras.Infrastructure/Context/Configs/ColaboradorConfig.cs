using HorasExtras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorasExtras.Infrastructure.Context.Configs
{
    public class ColaboradorConfig : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(empleado => empleado.Id);
            builder.Property(empleado => empleado.NumeroDocumento).HasMaxLength(20);
            builder.Property(empleado => empleado.Nombres).HasMaxLength(50);
            builder.Property(empleado => empleado.Apellido).HasMaxLength(50);

            builder.HasOne(e => e.Area)
              .WithMany(a => a.Empleados)
              .HasForeignKey(e => e.AreaId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
