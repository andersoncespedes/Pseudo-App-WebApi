using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder){
            builder.ToTable("tipo_persona");
            builder.Property(e => e.Descripcion)
            .IsRequired()
            .HasMaxLength(40);
        }
    }
