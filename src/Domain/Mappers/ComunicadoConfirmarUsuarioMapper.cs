using Domain.Entities;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.Mappers
{
    public static class ComunicadoConfirmarUsuarioMapper
    {
        public static ComunicadoConfirmarUsuarioViewModel ObterViewModelPorModel(ComunicadoConfirmarUsuario request)
        {
            if (request == null) return null;
            var response = new ComunicadoConfirmarUsuarioViewModel
            {
                Id = request.Id,
                ComunicadoId = request.ComunicadoId,
                UsuarioId = request.UsuarioId
            };

            return response;
        }

        public static IList<ComunicadoConfirmarUsuarioViewModel> ObterViewModelPorModel(IList<ComunicadoConfirmarUsuario> request)
        {
            var response = new List<ComunicadoConfirmarUsuarioViewModel>();
            foreach (var item in request)
            {
                response.Add(ObterViewModelPorModel(item));
            }

            return response;
        }
    }
}