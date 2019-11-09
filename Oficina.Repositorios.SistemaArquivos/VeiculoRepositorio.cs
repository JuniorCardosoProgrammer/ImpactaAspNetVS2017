using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaArquivos
{
    //Se não definir o escopo da classe ela, por definição, se define como internal. 
    public class VeiculoRepositorio : RepositorioBase
    {
        //Estes códigos foram remanejados para uma classe base no método construtor.
        //para encontrar as pastas do repositório quando hospedado na web.
        //static string caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
        //    ConfigurationManager.AppSettings["caminhoArquivoVeiculo"]);

        private XDocument arquivoXml;

        public VeiculoRepositorio() : base("caminhoArquivoVeiculo")
        {
            //arquivoXml = XDocument.Load(CaminhoArquivo); // Para acessar um arquivo Xml.
        }

        //É possível criar métodos genéricos que recebem o tipo de dado junto com o parâmetro.
        //O método gravar vira uma lista usando <> e passando o parâmetro do tipo dentro.
        //shift+12 é usado para ir pra onde o método esta sendo chamado.
        public void Gravar<T>(T veiculo)
        {
            var registro = new StringWriter();
            var serializador = new XmlSerializer(typeof(T));

            serializador.Serialize(registro, veiculo);

            //Remanejamos este diretório para dentro do método Gravar(), pois só precisamos acessar o arquivo xml quando vamos gravar o objeto.
            arquivoXml = XDocument.Load(CaminhoArquivo); // Para acessar um arquivo Xml.

            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));
            arquivoXml.Save(CaminhoArquivo);
        }
    }
}
