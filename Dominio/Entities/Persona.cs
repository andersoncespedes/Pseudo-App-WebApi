
namespace Dominio.Entities;

    public class Persona : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdGenereoFk { get; set; }
        public Genero Genero{ get; set; }
        public int IdCiudadFk { get; set; }
        public Ciudad Ciudad {  get; set; }
        public int IdTipoPersonaFk { get; set; }
        public TipoPersona TipoPersona { get; set; }
        public ICollection<Direccion> Direcciones { get; set;}
        public ICollection<Matricula> Matriculas { get; set; }
        public ICollection<TrainerSalon> TrainersSalones{ get; set; }
    }
