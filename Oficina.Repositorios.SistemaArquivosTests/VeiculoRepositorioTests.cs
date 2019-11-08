using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        private VeiculoRepositorio repositorio = new VeiculoRepositorio();

        [TestMethod()]
        public void GravarTest()
        {
            var veiculo = new VeiculoPasseio();

            veiculo.Placa = "ABC1234";
            veiculo.Ano = 2014;
            veiculo.Cambio = Cambio.Manual;
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Cor = new CorRepositorio().Obter(1);
            veiculo.Modelo = new ModeloRepositorio().Obter(2);
            veiculo.Observacao = "Obs";
            veiculo.TipoCarroceria = TipoCarroceria.Hatch;

            new VeiculoRepositorio().Gravar(veiculo);
        }
    }
}