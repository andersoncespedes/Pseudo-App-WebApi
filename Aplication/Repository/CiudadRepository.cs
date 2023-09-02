using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudadInterface
{
    private readonly ApiContext _context;
    public CiudadRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override void Add(Ciudad entity)
    {
        _context.Set<Ciudad>().Add(entity);
    }
    public override async Task<IEnumerable<Ciudad>> GetAll(){
        return await _context.Set<Ciudad>().ToListAsync();
    }
}
