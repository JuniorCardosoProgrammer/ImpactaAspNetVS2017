using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        ViagensOnlineDbContext db = new ViagensOnlineDbContext();

        [TestMethod()]
        public void InsertTest()
        {
            var destino = new Destino();
            destino.Nome = "Conheça um lugar onde se toma chá com o dedo mindinho levantando";
            destino.Cidade = "Londres";
            destino.Pais = "Inglaterra";
            destino.NomeImagem = "londres.png";
            db.Destinos.Add(destino);
            db.SaveChanges();
        }
    }
}