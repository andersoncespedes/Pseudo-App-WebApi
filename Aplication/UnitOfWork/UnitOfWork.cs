using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplication.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private PaisRepostory _paisRepostory;
        private DepartamentoRepository _departamentoRepository;
        private readonly ApiContext _context;
        public UnitOfWork(ApiContext context){
            _context = context;
        }
        public IPaisInterface Paises {get{
            if(_paisRepostory == null){
                _paisRepostory = new PaisRepostory(_context);
            }
            return _paisRepostory;
        }}
        public IDepartamentoInterface Departamentos {
            get{
                if(_departamentoRepository == null){
                    _departamentoRepository = new DepartamentoRepository(_context);
                }
                return _departamentoRepository;
            }
        }
        public Task<int> Save(){
            return _context.SaveChangesAsync();   
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}