using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
    public class RefeicaoTipoService : IRefeicaoTipoService
    {
        private readonly IRefeicaoTipoRepository _refeicaoTipoRepository;

        public RefeicaoTipoService(IRefeicaoTipoRepository refeicaoTipoRepository)
        {
            _refeicaoTipoRepository = refeicaoTipoRepository;
        }

        public IList<RefeicaoTipo> List(RefeicaoTipo refeicaoTipo)
        {
            var refeicaoTipos = _refeicaoTipoRepository.List(refeicaoTipo);
            return refeicaoTipos;
        }

        public void Add(RefeicaoTipo refeicaoTipo)
        {
            _refeicaoTipoRepository.Add(refeicaoTipo);
        }

        public void Update(RefeicaoTipo refeicaoTipo)
        {
            _refeicaoTipoRepository.Update(refeicaoTipo);
        }

        public void Delete(RefeicaoTipo refeicaoTipo)
        {
            _refeicaoTipoRepository.Delete(refeicaoTipo);
        }
    }
}
