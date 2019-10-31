using Oficina.Repositorios.SistemaArquivo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Oficina.Repositorios.SistemaArquivo.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        private CorRepositorio corRepositorio = new CorRepositorio();

        [TestMethod()]
        public void ObterTest()
        {
            var cores = corRepositorio.Obter();

            foreach (var cor in cores)
            {
                Console.WriteLine($"{cor.Id} - {cor.Nome}");
            }
        }

        [TestMethod()]
        public void ObterPorIdTest()
        {
            var cor = corRepositorio.Obter(1);

            Assert.AreEqual(cor.Nome, "Branco");

            cor = corRepositorio.Obter(7);
            Assert.IsNull(cor);
        }
    }
}