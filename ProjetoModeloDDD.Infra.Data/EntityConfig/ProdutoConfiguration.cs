using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.ProdutoID);

        builder.Property(p => p.Nome)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

        // A remoção dessa parte vai resolver o problema
        //builder.HasOne(p => p.Cliente)
        //        .WithMany()
        //        .HasForeignKey(p => p.ClienteID) 
        //        .OnDelete(DeleteBehavior.Restrict);
    }
}
