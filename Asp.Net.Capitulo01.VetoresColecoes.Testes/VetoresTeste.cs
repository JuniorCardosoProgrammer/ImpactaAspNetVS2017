using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asp.Net.Capitulo01.VetoresColecoes.Testes {
    [TestClass]
    public class VetoresTeste {
        [TestMethod]
        public void InicializacaoTeste() {
            var inteiros = new int[5];
            inteiros[0] = 48;
            inteiros[1] = 20;
            //inteiros[5] = 8; da erro por faltar dados nos índices anteriores do vetor
            //inteiros[-5] = 8; nunca usar números negativos pra índice de vetor

            var decimais = new decimal[] { 0.2m, 5, 2.52m, 1.9m };

            decimal[] maisDecimais = { 2, 5.8m, 0.5m };

            foreach (var @decimal in decimais) {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"O tamanho do vetor {nameof(decimais)} é: {decimais.Length}"); //string interpolada é usada pra concatenar string e dados de variáveis. inicia com $"" e tudo vai dentro das aspas duplas. Porém, as variáveis vão dentro de chaves {}.
        }

        [TestMethod]
        public void RedimensionamentoTeste() {
            var decimais = new decimal[] { 2.1m, 1.6m, -8 };

            Array.Resize(ref decimais, 5); // Redimensionar Vetor

            decimais[3] = 1.7m;

            Assert.AreEqual(decimais[4], 0m);
        }

        [TestMethod]
        public void OrdenacaoTeste() {
            var decimais = new decimal[] { 2.1m, 1.6m, -8 };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], -8);
        }

        [TestMethod]
        public void ParamsTeste() 
        {
            var decimais = new decimal[] { 2.1m, 1.6m, -8 };

            Console.WriteLine(Media(decimais));
            Console.WriteLine(Media(1.9m, 2.19m, 22, 0.3m));
            Console.WriteLine(decimais.Average());
        }

        //É possível ter diversos métodos com o mesmo nome, mas não pode ter os mesmos paarâmetros.

        private decimal Media(decimal valor1, decimal valor2)
        {
            return (valor1 + valor2) / 2;
        }

        // usar 3 barras "/"
        /// <summary>
        /// Calcula a média dos valores informados
        /// </summary>
        /// <param name="valores">Valores a serem calculados</param>
        /// <returns>A média</returns>
        private decimal Media(params decimal[] valores) // params só funciona com vetores. para passar os valores dentro do próprio método.
        {
            var soma = 0m;

            foreach (var valor in valores) {
                soma += valor;
            }

            //for (int i = 0; i < valores.Length; i++) {
            //    soma += valores[i];
            //}

            return soma / valores.Length;
        }

        // CTRL + O E CTRL + L serve para contrair e expandir os métodos e classes.

        [TestMethod]
        public void TodaStringEhUmVetorTeste() {
            var nome = "Vítor";

            Assert.AreEqual(nome[0],'V');

            //StringBuilder; 

            foreach (var letra in nome)
            {
                Console.Write(letra);
            }
        }
    }
}
