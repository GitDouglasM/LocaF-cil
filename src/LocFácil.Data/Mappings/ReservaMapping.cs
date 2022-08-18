using LocFácil.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocFácil.Data.Mappings
{
    public class ReservaMapping : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.DataInicio)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(v => v.DataFinal)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(v => v.Dinheiro)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(v => v.Cartao)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(v => v.Comentario)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(v => v.Seguro)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Reservas");
        }
    }
}
