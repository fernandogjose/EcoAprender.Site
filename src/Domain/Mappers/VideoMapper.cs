using Domain.Entities;
using Domain.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Mappers
{
    public static class VideoMapper
    {
        public static VideoViewModel ObterViewModelPorModel(Video request)
        {
            if (request == null) return null;
            var response = new VideoViewModel
            {
                Id = request.Id,
                Data = request.Data,
                Titulo = request.Titulo,
                Descricao = request.Descricao,
                Embed = request.Embed,
                Grupo = request.Grupo,
                EscolaId = request.EscolaId
            };

            return response;
        }

        public static IList<VideoViewModel> ObterViewModelPorModel(IList<Video> request)
        {
            var response = new List<VideoViewModel>();
            foreach (var item in request)
            {
                response.Add(ObterViewModelPorModel(item));
            }

            return response;
        }
    }
}