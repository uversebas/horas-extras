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
    public class AreaConfig : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(area => area.Id);
            builder.Property(area => area.Nombre).HasMaxLength(100);
            builder.HasOne(a => a.Lider)
               .WithMany()
               .HasForeignKey(a => a.LiderId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
