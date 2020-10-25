using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
    public class EvacuacaoService : IEvacuacaoService
    {
        private readonly IEvacuacaoRepository _evacuacaoRepository;

        public EvacuacaoService(IEvacuacaoRepository evacuacaoRepository)
        {
            _evacuacaoRepository = evacuacaoRepository;
        }

        public IList<Evacuacao> List(Evacuacao evacuacao)
        {
            var evacuacaos = _evacuacaoRepository.List(evacuacao);
            return evacuacaos;
        }

        public void Add(Evacuacao evacuacao)
        {
            _evacuacaoRepository.Add(evacuacao);
        }

        public void Update(Evacuacao evacuacao)
        {
            _evacuacaoRepository.Update(evacuacao);
        }

        public void Delete(Evacuacao evacuacao)
        {
            _evacuacaoRepository.Delete(evacuacao);
        }
    }
}
