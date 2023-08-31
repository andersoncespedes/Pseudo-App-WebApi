using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Departamento> Departamentos{ get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Salon> Salones { get; set;}
        public DbSet<Genero> Generos{ get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<TrainerSalon> TrainersSalones { get; set;}
        public DbSet<Matricula> Matriculas{ get; set; }
        public DbSet<TipoPersona> TiposPersonas{ get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base (options){
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Relacion Pais-Estado

            modelBuilder.Entity<Pais>().
            HasMany<Departamento>(e => e.Departamentos)
            .WithOne(e => e.Pais)
            .HasForeignKey(e => e.IdPaisFk);

            // Relacion Estado-Ciudad

            modelBuilder.Entity<Departamento>()
            .HasMany<Ciudad>(e => e.Ciudades)
            .WithOne(e => e.Departamento)
            .HasForeignKey(e => e.IdDepartamentoFk);

            // Relacion Persona-Matricula

            modelBuilder.Entity<Persona>()
            .HasMany<Matricula>(e => e.Matriculas)
            .WithOne(e => e.Persona)
            .HasForeignKey(e => e.IdPersonaFk);

            // Relacion Matricula-Salon

            modelBuilder.Entity<Salon>().
            HasMany<Matricula>(e => e.Matriculas)
            .WithOne(e => e.Salon)
            .HasForeignKey(e => e.IdSalonFk);

            // Relacion Persona-TipoPersona

            modelBuilder.Entity<TipoPersona>()
            .HasMany<Persona>(e => e.Personas)
            .WithOne(e => e.TipoPersona)
            .HasForeignKey(e => e.IdTipoPersonaFk);

            // Relacion Persona-Genero

            modelBuilder.Entity<Genero>()
            .HasMany<Persona>(e => e.Personas)
            .WithOne(e => e.Genero)
            .HasForeignKey(e => e.IdGenereoFk);

            // Relacion Persona-Direccion

            modelBuilder.Entity<Persona>()
            .HasMany<Direccion>(e => e.Direcciones)
            .WithOne(e => e.Persona)
            .HasForeignKey(e => e.IdPersonaFk);

            // Relacion muchos a muchos TrainerPersona
            modelBuilder.Entity<TrainerSalon>().HasKey(e => new { e.IdPersonaFk, e.IdSalonFk});

            modelBuilder.Entity<TrainerSalon>()
            .HasOne<Persona>(e => e.Persona)
            .WithMany(e => e.TrainersSalones)
            .HasForeignKey(e => e.IdPersonaFk);

            modelBuilder.Entity<TrainerSalon>()
            .HasOne<Salon>(e => e.Salon)
            .WithMany(e => e.TrainersSalones)
            .HasForeignKey(e => e.IdSalonFk);

        }
    }
}