using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asp.Net.Capitulo01.VetoresColecoes.Testes {
    [TestClass]
    public class ColecoesTeste {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int>(1000) { 16, 3, 2, -81};
            inteiros.Add(15); //para adicionar dados na List se usa o método Add()
            inteiros[0] = 23;
            //inteiros[10] = 2; Não é possível adicionar dados a um índice que não foi inicializado na list.
            var maisInteiros = new List<int> { 4, 2, 3 };

            inteiros.AddRange(maisInteiros); //Adiciona uma lista dentro da outra.

            inteiros.Insert(0, 29); // O método Insert() serve para inserir dados no índice definido. Porém, ele empurra o valor do índice que foi selecionado para o próximo índice.

            inteiros.Remove(2); // Não revome todos os elementos os elementos com o valor do parametro. só remove o primeiro valor encontrado.

            inteiros.RemoveAll(x => x == 2);

            inteiros.RemoveAt(4);

            inteiros.Sort(); // Ordenar list

            var primeiro = inteiros[0];
            primeiro = inteiros.First(); // para trazer o primeiro índice da List

            var ultimo = inteiros.Last();
            ultimo = inteiros[inteiros.Count - 1]; // para trazer o ultimo índice da List

            foreach (var inteiro in inteiros) {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)} : {inteiro}");
            }
        }
    }
}
