﻿using AspNet.Capitulo03.Portfolio.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;

namespace AspNet.Capitulo03.Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContatoViewModel contato)
        {
            //  var nome = formulario["nome"];
            if (!ModelState.IsValid)
            {
                return View(contato);
            }
            var stringConexao = ConfigurationManager
                .ConnectionStrings["portfolioConnectionString"].ConnectionString;
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                const string instrucao = @"INSERT INTO [dbo].[Contato]
                                       ([Nome]
                                       ,[Email]
                                       ,[Mensagem])
                                 VALUES
                                       (@Nome
                                       ,@Email
                                       ,@Mensagem)";
                // ToDo: não esqueça do meu IDisposable.

                using (var comando = new SqlCommand(instrucao, conexao))
                {
                    comando.Parameters.AddWithValue("@Nome", contato.Nome);
                    comando.Parameters.AddWithValue("@Email", contato.Email);
                    comando.Parameters.AddWithValue("@Mensagem", contato.Mensagem);
                    comando.ExecuteNonQuery();
                }

                //conexao.Close(); a classe SqlConnection tem internamento o Close 

            }

            ViewBag.Sucesso = true;
            ModelState.Clear();
            return View();

        }

        public ActionResult Portfolio()
        {
            const string diretorioImagens = "/Content/Imagens/Portfolio";

            //para encontrar o diretório dos arquivos no servidor onde a aplicação estiver rodando.
            var caminhos = Directory.EnumerateFiles(Server.MapPath(diretorioImagens));

            var portfolioViewModel = new PortfolioViewModel();

            foreach (var caminho in caminhos)
            {
                portfolioViewModel.CaminhosImagens.Add($"{diretorioImagens}/{Path.GetFileName(caminho)}");
            }

            return View(portfolioViewModel);
        }

    }
}