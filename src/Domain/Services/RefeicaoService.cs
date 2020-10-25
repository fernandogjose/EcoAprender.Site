using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
    public class RefeicaoService : IRefeicaoService
    {
        private readonly IRefeicaoRepository _refeicaoRepository;

        public RefeicaoService(IRefeicaoRepository refeicaoRepository)
        {
            _refeicaoRepository = refeicaoRepository;
        }

        public IList<Refeicao> List(Refeicao refeicao)
        {
            var refeicaos = _refeicaoRepository.List(refeicao);
            return refeicaos;
        }

        public void Add(Refeicao refeicao)
        {
            _refeicaoRepository.Add(refeicao);
        }

        public void Update(Refeicao refeicao)
        {
            _refeicaoRepository.Update(refeicao);
        }

        public void Delete(Refeicao refeicao)
        {
            _refeicaoRepository.Delete(refeicao);
        }
    }
}
