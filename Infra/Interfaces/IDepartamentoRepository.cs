using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IDepartamentoRepository : IBaseRepository<Departamento>
    {
        Task<Departamento> GetByName(string name);
    }
}
