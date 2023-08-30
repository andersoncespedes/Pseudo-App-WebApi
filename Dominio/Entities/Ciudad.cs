using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

public class Ciudad : BaseEntity
{
    public string nombreCiudad { get; set; }
    public int IdDepartamentoFk { get; set; }
    public Departamento Departamento {get ; set; } 
}
