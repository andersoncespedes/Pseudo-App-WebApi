using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Entities;
namespace Dominio.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    IEnumerable<T> Find(Expression<Func<T,bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> Entity);
    void RemoveRange(IEnumerable<T> Entity);
    void Update(T entity);
    void Remove(T entity);
}
