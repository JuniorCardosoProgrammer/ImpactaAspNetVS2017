using System.Collections.Generic;
using System.IO;
using ViagensOnline.Dominio;
using ViagensOnline.Mvc.Models;

namespace ViagensOnline.Mvc.Mapeamento
{
    public class Mapeamento
    {
        private string caminhoImagensDestinos;

        public List<DestinoViewModel> Mapear(List<Destino> destinos)
        {
            var viewModels = new List<DestinoViewModel>();

            foreach (var destino in destinos)
            {
                viewModels.Add(Mapear(destino));
            }

            return viewModels;
        }

        public DestinoViewModel Mapear(Destino destino)
        {
            var viewModel = new DestinoViewModel();

            viewModel.CaminhoImagem = Path.Combine(caminhoImagensDestinos, destino.NomeImagem);
            viewModel.Cidade = destino.Cidade;
            viewModel.Id = destino.Id;
            viewModel.Nome = destino.Nome;
            viewModel.Pais = destino.Pais;

            return viewModel;
        }

        public Destino Mapear(DestinoViewModel viewModel)
        {
            var destino = new Destino();

            destino.NomeImagem = viewModel.ArquivoFoto.FileName;
            destino.Cidade = viewModel.Cidade;
            destino.Id = viewModel.Id;
            destino.Nome = viewModel.Nome;
            destino.Pais = viewModel.Pais;

            return destino;
        }
    }
}