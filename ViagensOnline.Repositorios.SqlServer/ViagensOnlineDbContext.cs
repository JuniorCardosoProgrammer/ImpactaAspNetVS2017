using System.Data.Entity;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer
{
    public class ViagensOnlineDbContext : DbContext
    {
        public ViagensOnlineDbContext() : base("ViagensOnlineConnectionString")
        {

        }

        public DbSet<Destino> Destinos { get; set; }
    }
}
