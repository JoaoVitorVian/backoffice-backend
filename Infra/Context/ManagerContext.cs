using Domain.Entity;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext() { }
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new DepartamentoMap());
        }
    }
}