using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;

namespace Persistencia.Data.Configuration;
public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder){
        builder.ToTable("direccion");
        builder.Property(e => e.TipoVia)
        .IsRequired()
        .HasMaxLength(20);
        builder.Property(e => e.Letra)
        .IsRequired()
        .HasColumnType("char")
        .HasMaxLength(1);
        builder.Property(e => e.SufijoCardinal)
        .IsRequired()
        .HasMaxLength(30);
    }
}
