using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Mappers
{
    public static class EscolaMapper
    {
        public static EscolaViewModel ObterViewModelPorModel(Escola request)
        {
            if (request == null) return new EscolaViewModel();
            var response = new EscolaViewModel
            {
                Id = request.Id,
                Nome = request.Nome
            };

            return response;
        }
    }
}