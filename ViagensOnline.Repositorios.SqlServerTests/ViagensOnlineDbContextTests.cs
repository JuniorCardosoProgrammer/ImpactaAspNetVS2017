using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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

        [TestMethod()]
        public void AtualizarTeste()
        {
            //db.Destinos.Where();
            var destino = db.Destinos.Find(1);
            destino.NomeImagem = "londres2.png";
            db.SaveChanges();
            //destino = db.Destinos.Find(1);
            //destino = db.Destinos.Where(d => d.Id == 1).SingleOrDefault();
            destino = db.Destinos.SingleOrDefault(d => d.Id == 1);
            Assert.AreEqual(destino.NomeImagem, "londres2.png");
        }

        [TestMethod()]
        public void ExcluirTeste()
        {
            var destino = db.Destinos.Find(1);

            db.Destinos.Remove(destino);

            db.SaveChanges();

            destino = db.Destinos.Find(1);

            Assert.IsNull(destino);
        }
    }
}