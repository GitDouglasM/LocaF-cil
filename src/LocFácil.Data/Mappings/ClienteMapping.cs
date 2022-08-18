using LocFácil.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocFácil.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(p => p.Rg)
                .IsRequired()
                .HasColumnType("varchar(7)");

            builder.Property(p => p.Celular)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Complemento)
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Clientes");
        }
    }
}
