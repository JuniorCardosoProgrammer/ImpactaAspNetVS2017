using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class ModeloRepositorio : RepositorioBase
    {
        //Estes códigos foram remanejados para uma classe base no método construtor.
        //para encontrar as pastas do repositório quando hospedado na web.
        //static string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        //    ConfigurationManager.AppSettings["caminhoArquivoModelo"]);

        // O readonly especifica que este campo/field vira somente leitura. Porém, pode ser alterado o seu valor apartir do método construtor. 
        private XDocument arquivoXml;

        public ModeloRepositorio() : base("caminhoArquivoModelo")
        {
        }

        public List<Modelo> ObterPorMarca(int marcaId)
        {
            var modelos = new List<Modelo>();
            arquivoXml = XDocument.Load(CaminhoArquivo); // Para acessar um arquivo Xml

            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (elemento.Element("marcaid").Value == marcaId.ToString())
                //if (Convert.ToInt32(elemento.Element("marcaId").Value) == marcaId)
                {
                    var modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;

                    var marcaRepositorio = new MarcaRepositorio();
                    modelo.Marca = marcaRepositorio.Obter(marcaId);

                    modelos.Add(modelo);
                }
            }

            return modelos;
        }

        // Na orientação a objetos o polimorfismo permite métodos com mesmo nome mas os parâmetros devem ser de tipos diferentes.
        public Modelo Obter(int id)
        {
            Modelo modelo = null;
            arquivoXml = XDocument.Load(CaminhoArquivo); // Para acessar um arquivo Xml

            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (elemento.Element("id").Value == (id.ToString()))
                //if (Convert.ToInt32(elemento.Element("marcaId").Value) == marcaId)
                {
                    modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;

                    var marcaRepositorio = new MarcaRepositorio();
                    modelo.Marca = marcaRepositorio.Obter(Convert.ToInt32(elemento.Element("marcaid").Value));

                    break;
                }
            }
            return modelo;
        }

    }
}
