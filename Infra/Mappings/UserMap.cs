using Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mappings
{
 public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                 .UseIdentityColumn()
                 .HasColumnType("BIGINT");

        builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(80)");

        builder.Property(x => x.TipoDePessoa)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("tipoPessoa")
                .HasColumnType("VARCHAR(10)");

        builder.Property(x => x.Apelido)
                .HasMaxLength(50)
                .HasColumnName("apelido")
                .HasColumnType("VARCHAR(50)");


        builder.Property(x => x.Localidade)
                 .IsRequired()
                 .HasMaxLength(100)
                 .HasColumnName("localidade")
                 .HasColumnType("VARCHAR(100)");

        builder.Property(x => x.Cep)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("cep")
                    .HasColumnType("VARCHAR(40)");

            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("bairro")
                .HasColumnType("VARCHAR(100)");

        builder.Property(x => x.Documento)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("documento")
                .HasColumnType("VARCHAR(80)");

        builder.Property(x => x.Qualificacoes)
               .IsRequired()
               .HasMaxLength(40)
               .HasColumnName("qualificacoes")
               .HasColumnType("VARCHAR(40)");
        }
    }
}
