using Domain.Entities;
using Domain.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Mappers
{
    public static class ComunicadoMapper
    {
        public static ComunicadoViewModel ObterViewModelPorModel(Comunicado request)
        {
            if (request == null) return null;
            var response = new ComunicadoViewModel
            {
                Id = request.Id,
                Data = request.Data,
                Titulo = request.Titulo,
                Descricao = request.Descricao,
                Confirmar = request.Confirmar,
                ComunicadoConfirmarUsuarios = ComunicadoConfirmarUsuarioMapper.ObterViewModelPorModel(request.ComunicadoConfirmarUsuarios.ToList())
            };

            return response;
        }

        public static IList<ComunicadoViewModel> ObterViewModelPorModel(IList<Comunicado> request)
        {
            var response = new List<ComunicadoViewModel>();
            foreach (var item in request)
            {
                response.Add(ObterViewModelPorModel(item));
            }

            return response;
        }
    }
}