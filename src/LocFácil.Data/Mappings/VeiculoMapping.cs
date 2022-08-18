using LocFácil.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocFácil.Data.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(v => v.Cor)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(v => v.Marca)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(v => v.AnoFabricacao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(v => v.NumPortas)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(v => v.TipoCombustivel)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(v => v.ArCondicionado)
                .HasColumnType("bit");

            builder.Property(v => v.Direcao)
                .HasColumnType("bit");

            builder.Property(v => v.FreioAbs)
                .HasColumnType("bit");

            builder.Property(v => v.Trava)
                .HasColumnType("bit");

            builder.Property(v => v.Airbag)
                .HasColumnType("bit");

            builder.Property(v => v.QtdLugar)
                .HasColumnType("int");

            builder.Property(v => v.Vidro)
                .HasColumnType("bit");

            builder.Property(v => v.FarolNeblina)
                .HasColumnType("bit");

            builder.Property(v => v.Descricao)
                .HasColumnType("varchar(1000)");

            builder.Property(v => v.Situacao)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Veiculos");
        }
    }
}
