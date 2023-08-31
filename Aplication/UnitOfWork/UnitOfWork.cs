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
        private PaisRepostory paisRepostory;
        private readonly ApiContext context;
        public UnitOfWork(ApiContext context){
            this.context = context;
        }
        public IPaisInterface Paises {get{
            if(paisRepostory == null){
                paisRepostory = new PaisRepostory(this.context);
            }
            return paisRepostory;
        }}

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}