using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivo
{
    public class CorRepositorio
    {
        public List<Cor> Obter() // para fazer teste unitário no método basta clicar com o botão direito e opção criar testes de unidade.
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(@"Dados\Cor.txt")) // ReadallLines retorna um vetor de strings.
            {
                var cor = new Cor();
                cor.Id = Convert.ToInt32(linha.Substring(0, 5)); // Converter em Int.
                cor.Nome = linha.Substring(5); 

                cores.Add(cor);
            }

            return cores;
        }
    }
}
