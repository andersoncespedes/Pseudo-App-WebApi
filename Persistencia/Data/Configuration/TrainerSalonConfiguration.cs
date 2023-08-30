using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;

namespace Persistencia.Data.Configuration;

    public class TrainerSalonConfiguration : IEntityTypeConfiguration<TrainerSalon>
    {
        public void Configure(EntityTypeBuilder<TrainerSalon> builder){
            builder.ToTable("trainer_salon");
        }
    }
