using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Mappers
{
    public static class GrupoMapper
    {
        public static GrupoViewModel ObterViewModelPorModel(Grupo grupo)
        {
            if (grupo == null) return null;
            var response = new GrupoViewModel
            {
                Id = grupo.Id,
                Descricao = grupo.Descricao,
            };

            return response;
        }

        public static IList<GrupoViewModel> ObterViewModelsPorModels(IList<Grupo> grupos)
        {
            var response = new List<GrupoViewModel>();
            foreach (var grupo in grupos)
            {
                var grupoViewModel = ObterViewModelPorModel(grupo);
                response.Add(grupoViewModel);
            }

            return response;
        }
    }
}