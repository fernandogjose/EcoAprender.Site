using Domain.Entities;
using Domain.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Domain.Mappers
{
    public static class AtividadeMapper
    {
        public static AtividadeViewModel ObterViewModelPorModel(Atividade request)
        {
            if (request == null) return null;

            var path = string.Format(@"C:\inetpub\ecoaprender.com.br\img\atividades\{0}\", request.Id);
            var fotos = new List<string>();

            if (Directory.Exists(path))
            {
                foreach (var foto in Directory.GetFiles(path))
                {
                    fotos.Add(string.Format("http://www.ecoaprender.com.br/img/atividades/{0}/{1}", request.Id, Path.GetFileName(foto)));
                }
            }

            var response = new AtividadeViewModel
            {
                Id = request.Id,
                Data = request.Data,
                Titulo = request.Titulo,
                Resumo = request.Resumo,
                Completa = request.Completa,
                CompletaApp = request.CompletaApp,
                CompletaAppFormatada = request.CompletaApp,
                FotoCapa = request.FotoCapa,
                FotoResumo = request.FotoResumo,
                Link = request.Link,
                MetaDescription = request.MetaDescription,
                MetaTitle = request.MetaTitle,
                Grupo = request.Grupo,
                EscolaId = request.EscolaId,
                Fotos = fotos
            };

            if (request.GrupoRelacionamento != null)
            {
                response.GrupoViewModel = new GrupoViewModel
                {
                    Id = request.GrupoRelacionamento.Id,
                    Descricao = request.GrupoRelacionamento.Descricao
                };
            }

            return response;
        }

        public static IList<AtividadeViewModel> ObterViewModelPorModel(IList<Atividade> request)
        {
            var response = new List<AtividadeViewModel>();
            foreach (var item in request)
            {
                var atividadeViewModel = ObterViewModelPorModel(item);

                if (atividadeViewModel.Id > 55)
                {
                    atividadeViewModel.CompletaAppFormatada = atividadeViewModel.CompletaAppFormatada.Replace(".", ".<br /><br />");
                }

                response.Add(atividadeViewModel);
            }

            foreach (var atividade in response.Where(x => x.Fotos.Any()))
            {
                foreach (var foto in atividade.Fotos)
                {
                    atividade.CompletaAppFormatada = string.Format("{0} <img src='{1}' class='full-image' alt='{2}' title ='{2}' />", atividade.CompletaAppFormatada, foto, atividade.Titulo);
                }
            }

            return response;
        }
    }
}