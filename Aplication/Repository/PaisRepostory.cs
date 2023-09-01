using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
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
    public override async void Add(Pais entity){
        _context.Set<Pais>().Add(entity);
    }
    public override void Remove(Pais entity){
        _context.Set<Pais>().Remove(entity);
    }
}
