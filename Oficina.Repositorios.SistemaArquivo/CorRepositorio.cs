using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivo
{
    public class CorRepositorio
    {
        private string caminhoArquivo = ConfigurationManager.AppSettings["caminhoArquivoCor"]; // classe que lê arquivo de parametrização.

        // para fazer teste unitário no método basta clicar com o botão direito e opção criar testes de unidade.
        public List<Cor> Obter() 
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(caminhoArquivo)) // ReadallLines retorna um vetor de strings.
            {
                var cor = new Cor();
                cor.Id = Convert.ToInt32(linha.Substring(0, 5)); // Converter em Int.
                cor.Nome = linha.Substring(5); 

                cores.Add(cor);
            }

            return cores;
        }

        public Cor Obter(int id)
        {
            Cor cor = null;

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                //ctrl + k + s para colocar um comando envolta de um grupo de códigos selecionados
                var linhaId = Convert.ToInt32(linha.Substring(0, 5));

                if (id == linhaId)
                {
                    cor = new Cor();
                    cor.Id = linhaId;
                    cor.Nome = linha.Substring(5);

                    break;
                }

                //if (id == null)
                //{
                //    Console.WriteLine("Cor Não encontrada!");
                //}

                //Console.WriteLine($"{cor.Id} - {cor.Nome}");
            }
            
            return cor;
        }

    }
}
