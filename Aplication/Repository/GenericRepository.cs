using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using System.Linq.Expressions;

namespace Aplication.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApiContext _context;
    public GenericRepository(ApiContext context){
       _context = context;
    }
    public virtual async Task<IEnumerable<T>> GetAll(){
        return await _context.Set<T>().ToListAsync();
    }
    public virtual async Task<T> GetById(int id){
        return await _context.Set<T>().FindAsync(id);
    }
    public virtual  IEnumerable<T> Find(Expression<Func<T,bool>> expression){
        return _context.Set<T>().Where(expression);
    }
    public virtual void Add(T entity){
        _context.Set<T>().Add(entity);
    }
    public virtual void AddRange(IEnumerable<T> entities){
        _context.Set<T>().AddRange(entities);
    }
    public virtual void Update(T entity){
        _context.Set<T>().Update(entity);
    }
    public virtual void RemoveRange (IEnumerable<T> entities){
        _context.Set<T>().RemoveRange(entities);
    }

    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}
