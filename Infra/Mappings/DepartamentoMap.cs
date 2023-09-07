using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.NomeDepartamento)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nomeDepartamento")
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.NomeResponsavel)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnName("nomeResponsavel")
               .HasColumnType("VARCHAR(100)"); 
        }
    }
}
