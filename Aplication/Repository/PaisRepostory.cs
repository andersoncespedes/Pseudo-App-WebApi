using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
namespace Aplication.Repository;

public class PaisRepostory : GenericRepository<Pais>, IPaisInterface
{
    private readonly ApiContext _context;
    public PaisRepostory(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Pais>> GetAll(){
        return await _context.Set<Pais>().Include(e => e.Departamentos).ToListAsync();
    }
    public override async Task<Pais> GetById(int id){
        return await _context.Set<Pais>().FindAsync(id);
    }
}
