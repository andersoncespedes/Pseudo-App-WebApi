using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistencia.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{       
    public void Configure(EntityTypeBuilder<Departamento> builder){
        builder.ToTable("departamento");
        builder.Property(e => e.NombreDepartamento)
        .IsRequired()
        .HasMaxLength(30);
    }
}
