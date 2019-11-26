using Loja.Dominio;
using Loja.Repositorio.SqlServer.ModelConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Loja.Repositorio.SqlServer
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext() : base("LojaSqlServer")
        {
            // Digitar esses comandos no console do nuget.
            // O projeto deverá ter uma string de conexão
            // Deve estar selecionado no solution e no console do nuget
            // 1. Enable-Migrations - apenas uma vez.
            // 2. Add-Migration NomeDaModificacao
            // 3. Update-Database
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
