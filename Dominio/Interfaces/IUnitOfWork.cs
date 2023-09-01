namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IPaisInterface Paises {get;}  
    IDepartamentoInterface Departamentos {get;}
    Task<int> Save();
}
