using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class MarcaRepositorio : RepositorioBase
    {
        //Estes códigos foram remanejados para uma classe base no método construtor.
        //private string caminhoArquivo = 
        //    ConfigurationManager.AppSettings["caminhoArquivoMarca"];
        //static string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        //    ConfigurationManager.AppSettings["caminhoArquivoMarca"]);

        public MarcaRepositorio() : base("caminhoArquivoMarca")
        {

        }

        public List<Marca> Obter()
        {
            var marcas = new List<Marca>();

            foreach (var linha in File.ReadAllLines(CaminhoArquivo))
            {
                var propriedades = linha.Split('|');

                var marca = new Marca();
                marca.Id = Convert.ToInt32(propriedades[0]);
                marca.Nome = propriedades[1];

                marcas.Add(marca);
            }

            return marcas;
        }

        public Marca Obter(int id)
        {
            Marca marca = null;

            foreach (var linha in File.ReadAllLines(CaminhoArquivo))
            {
                var propriedades = linha.Split('|');
                var linhaId = Convert.ToInt32(propriedades[0]);

                if (id == linhaId)
                {
                    marca = new Marca();
                    marca.Id = linhaId;
                    marca.Nome = propriedades[1];
                    //marca.TipoVeiculo = propriedades[2].ToString();

                    break;
                }
            }

            return marca;
        }


    }
}
