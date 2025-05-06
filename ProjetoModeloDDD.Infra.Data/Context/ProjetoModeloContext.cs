using Microsoft.EntityFrameworkCore;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Infra.Data.EntityConfig;

namespace ProjetoModeloDDD.Infra.Data.Context
{
    public class ProjetoModeloContext : DbContext
    {
        public ProjetoModeloContext(DbContextOptions<ProjetoModeloContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove pluralização
            modelBuilder.Entity<Cliente>().ToTable("Cliente");

            // Desativa DeleteBehavior.Cascade para todos os relacionamentos (OneToMany e ManyToMany)
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict; // Restringe a exclusão para todos os relacionamentos
                }
            }

            // Configura todas as propriedades string para usar varchar(100)
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    property.SetColumnType("varchar(100)");
                }
            }

            // Aplica as configurações específicas de entidades, como a do ClienteConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjetoModeloContext).Assembly);

            modelBuilder.Entity<Produto>().ToTable("Produto");


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now; // Atribui a data de cadastro ao adicionar uma nova entidade
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false; // Evita a alteração do campo DataCadastro
                }
            }

            return base.SaveChanges(); // Salva as mudanças no banco de dados
        }
    }
}
