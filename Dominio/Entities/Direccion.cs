namespace Dominio.Entities;

public class Direccion : BaseEntity
{
    public string TipoVia {get; set;}
    public int Numero {get; set; }
    public string Letra {get; set; }
    public string SufijoCardinal { get; set; }
    public int NumeroViaSecundaria {get; set;}
    public string LetraViaSecundaria {get; set; }
    public string SufijoCords {get; set;}
    public int IdPersonaFk {get; set;}
    public Persona Persona {get; set;}        
}
