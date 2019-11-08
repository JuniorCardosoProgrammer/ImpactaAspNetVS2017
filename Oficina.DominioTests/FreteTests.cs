using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Oficina.Dominio.Tests
{
    [TestClass()]
    public class FreteTests
    {

        [TestMethod()]
        public void CalcularTest()
        {
            var frete = new Frete(UF.MG, 20.2M);
            frete.Cliente = new Cliente { Nome = "Zé"};

            Assert.AreEqual(frete.ValorFrete, 0.35m);
            Assert.AreEqual(frete.ValorTotal, 27.27m);
        }
    }
}