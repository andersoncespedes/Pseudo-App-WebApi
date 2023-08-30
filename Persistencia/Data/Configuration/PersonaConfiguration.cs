using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder){
            builder.ToTable("persona");
            builder.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50);
            builder.Property(e => e.Apellido)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
