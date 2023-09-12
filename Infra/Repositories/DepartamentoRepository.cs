using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class DepartamentoRepository : BaseRepository<Departamento>, IDepartamentoRepository
    {
        private readonly ManagerContext _context;

        public DepartamentoRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Departamento> GetByName(string name)
        {
            var dep = await _context.Departamentos
                                     .Where(
                                        x => x.NomeDepartamento.ToLower() == name.ToLower()
                                     )
                                     .AsNoTracking()
                                     .ToListAsync();

            return dep.FirstOrDefault();
        }
    }
}
