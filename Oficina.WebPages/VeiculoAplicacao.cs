using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao
    {
        //readonly serve para indicar que o objeto seja somente para leitura.
        //private define o escopo para ser chamado somente dentro da classe.
        private readonly CorRepositorio corRepositorio = new CorRepositorio();
        private readonly MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        private readonly ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        private readonly VeiculoRepositorio veiculoRepositorio = new VeiculoRepositorio();

        //ctor + tab +tab  Atalho para criar métodos.
        public VeiculoAplicacao()
        {
            PopularControles();
        }

        //atalho pra colocar uma propriedade: escrever prop e depois apertar tab duas vezes.
        public string MarcaSelecionada { get; set; }
        public List<Cor> Cores { get; set; }
        public List<Marca> Marcas { get; set; }
        public List<Modelo> Modelos { get; set; } = new List<Modelo>();
        public List<Combustivel> Combustiveis { get; set; }
        public List<Cambio> Cambios { get; set; }
        public List<TipoCarroceria> TipoCarroceria { get; set; }
        public string MensagemErro { get; private set; }

        private void PopularControles()
        {
            Cores = corRepositorio.Obter();

            Marcas = marcaRepositorio.Obter();

            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = modeloRepositorio.ObterPorMarca(Convert.ToInt32(MarcaSelecionada));
            }
            
            Combustiveis = Enum.GetValues(typeof(Combustivel))
                .Cast<Combustivel>()
                .ToList();

            Cambios = Enum.GetValues(typeof(Cambio))
                .Cast<Cambio>()
                .ToList();

            TipoCarroceria = Enum.GetValues(typeof(TipoCarroceria))
                .Cast<TipoCarroceria>()
                .ToList();
        }

        public void Gravar()
        {
            // ctrl + k + s = para inserir uma seleção de linhas dentro de um código.
            try
            {
                //if (true)
                //{
                //    var veiculo = new VeiculoPasseio();
                //}

                var veiculo = new VeiculoPasseio();

                var formulario = HttpContext.Current.Request.Form;

                veiculo.Placa = formulario["placa"].ToString();
                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                // converte o enumerador em inteiro e depois faz um cast (pro tipo do enumedaror) para pegar o valor do enumerador.
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
                //instância o repositorio, chama o método e converte o valor do parâmetro para inteiro.
                veiculo.Cor = corRepositorio.Obter(Convert.ToInt32(formulario["cor"]));
                veiculo.Modelo = modeloRepositorio.Obter(Convert.ToInt32(formulario["modelo"]));
                veiculo.Observacao = formulario["observacao"].ToString();
                veiculo.TipoCarroceria = (TipoCarroceria)Convert.ToInt32(formulario["carroceria"]); ;

                veiculoRepositorio.Gravar(veiculo);
            }
            //existem inúmeras exceptions do framework. Basta chamar o exception como parâmetro do método catch.
            catch (FileNotFoundException ex)
            {
                MensagemErro = $"Arquivo {ex.FileName} não encontrado!";
            }
            //só executado quando ocorre um erro na aplicação.
            catch (DirectoryNotFoundException)
            {
                MensagemErro = "Caminho não encontrado";
            }
            catch (Exception)
            {
                MensagemErro = "Eita, algo deu errado!";
            }
            finally
            {
                // finally não é obrigatório e roda sempre, com sucesso ou erro.
                // se tiver um return, o finally também é executado!!!
            }
        }
    }
}