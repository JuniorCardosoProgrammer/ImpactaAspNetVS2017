using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNet.Capitulo01.Repeticao.Testes {
    [TestClass]
    public class RepeticaoTeste 
    {
        [TestMethod]
        public void TabuadaTeste()
        {
            for (int a = 1; a <= 10; a++) { // ctrl+r+r para trocar o nome de todas as referências. Neste exemplo troquei o nome da variável i para a e todas as outras referências a variável i foram trocados para a.
                for (int j = 0; j <= 10; j++) {
                    Console.WriteLine($"{a} X {j} = {a*j}"); // cw e tecla tab duas vezes automatiza o código. i+"X"+j+"="+resultado
                }
                Console.WriteLine(new string('-', 25));
            }
        }

        [TestMethod] // testem tab duas vezes é o atalho para criar o método de teste.
        public void EstruturaForTeste()
        {
            var i = 1;

            for (Console.WriteLine("Iniciou"); i <= 3; Console.WriteLine(++i))
            {
                //i++;
            }
            Console.WriteLine("Encerrou");

            /*
            for(1. Inicialização; 2. Critério; 4. Pós-Execução)
            {
                3. Execução; 
            }
             */
        }

        [TestMethod]
        public void ForApenasComCondicaoTeste() {
            var i = 1;

            for (; i <= 3;) {
                Console.WriteLine(i++);
            }
        }

        [TestMethod]
        public void ContinueTeste() {
            for (int i = 1; i <= 10; i++) {
                if (i <= 5) {
                    continue; //Associado a estruturas de repetição serve para ignorar linhas de código de acordo com critério pré-definidos e continuar a estrutura de repetição.
                }
                Console.WriteLine(i);

            }
        }

        [TestMethod]
        public void BreakTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i > 5) {
                    break; //Encerra, interrompe o bloco de execução.
                }
                Console.WriteLine(i);

            }
        }

    }
}
