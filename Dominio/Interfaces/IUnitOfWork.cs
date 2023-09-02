namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IPaisInterface Paises {get;}  
    IDepartamentoInterface Departamentos {get;}
    ICiudadInterface Ciudades {get;}
    Task<int> Save();
}
