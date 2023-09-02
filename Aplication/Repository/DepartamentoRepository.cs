using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistencia.Data;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Aplication.Repository;

public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamentoInterface
{
    private readonly ApiContext _context;
    public DepartamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Departamento>> GetAll(){
        return await _context.Set<Departamento>().Include(e => e.Ciudades).ToListAsync();
    }
    public override async Task<Departamento> GetById(int id){
        return await _context.Set<Departamento>().FindAsync(id);
    }
    public override void Add(Departamento departamento){
        _context.Set<Departamento>().Add(departamento);
    }
    public override void Remove(Departamento entity)
    {
        _context.Set<Departamento>().Remove(entity);
    }
    public override void Update(Departamento entity, Departamento viejo)
    {
        viejo.NombreDepartamento = entity.NombreDepartamento;
        viejo.IdPaisFk = entity.IdPaisFk;
    }
}
