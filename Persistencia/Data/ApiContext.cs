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

        }
    }
}