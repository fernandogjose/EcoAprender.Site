using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
    public class RefeicaoStatusService : IRefeicaoStatusService
    {
        private readonly IRefeicaoStatusRepository _refeicaoStatusRepository;

        public RefeicaoStatusService(IRefeicaoStatusRepository refeicaoStatusRepository)
        {
            _refeicaoStatusRepository = refeicaoStatusRepository;
        }

        public IList<RefeicaoStatus> List(RefeicaoStatus refeicaoStatus)
        {
            var refeicaoStatuss = _refeicaoStatusRepository.List(refeicaoStatus);
            return refeicaoStatuss;
        }

        public void Add(RefeicaoStatus refeicaoStatus)
        {
            _refeicaoStatusRepository.Add(refeicaoStatus);
        }

        public void Update(RefeicaoStatus refeicaoStatus)
        {
            _refeicaoStatusRepository.Update(refeicaoStatus);
        }

        public void Delete(RefeicaoStatus refeicaoStatus)
        {
            _refeicaoStatusRepository.Delete(refeicaoStatus);
        }
    }
}
