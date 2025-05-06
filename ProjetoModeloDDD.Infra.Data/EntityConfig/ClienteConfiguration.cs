using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnType("varchar(150)");

            builder.Property(c => c.Sobrenome)
                   .IsRequired()
                   .HasMaxLength(150)
                   .HasColumnType("varchar(150)");

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnType("varchar(255)");
        }
    }
}
