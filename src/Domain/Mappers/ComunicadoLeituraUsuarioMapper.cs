using Domain.Entities;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.Mappers
{
    public static class ComunicadoLeituraUsuarioMapper
    {
        public static ComunicadoLeituraUsuarioViewModel ObterViewModelPorModel(ComunicadoLeituraUsuario request)
        {
            if (request == null) return null;
            var response = new ComunicadoLeituraUsuarioViewModel
            {
                Id = request.Id,
                ComunicadoId = request.ComunicadoId,
                UsuarioId = request.UsuarioId
            };

            return response;
        }

        public static IList<ComunicadoLeituraUsuarioViewModel> ObterViewModelPorModel(IList<ComunicadoLeituraUsuario> request)
        {
            var response = new List<ComunicadoLeituraUsuarioViewModel>();
            foreach (var item in request)
            {
                response.Add(ObterViewModelPorModel(item));
            }

            return response;
        }
    }
}