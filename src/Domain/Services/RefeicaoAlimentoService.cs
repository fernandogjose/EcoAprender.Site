using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
    public class RefeicaoAlimentoService : IRefeicaoAlimentoService
    {   
        private readonly IRefeicaoAlimentoRepository _refeicaoAlimentoRepository;

        public RefeicaoAlimentoService(IRefeicaoAlimentoRepository refeicaoAlimentoRepository)
        {
            _refeicaoAlimentoRepository = refeicaoAlimentoRepository;
        }

        public IList<RefeicaoAlimento> List(RefeicaoAlimento refeicaoAlimento)
        {
            var refeicaoAlimentos = _refeicaoAlimentoRepository.List(refeicaoAlimento);
            return refeicaoAlimentos;
        }

        public void Add(RefeicaoAlimento refeicaoAlimento)
        {
            _refeicaoAlimentoRepository.Add(refeicaoAlimento);
        }

        public void Update(RefeicaoAlimento refeicaoAlimento)
        {
            _refeicaoAlimentoRepository.Update(refeicaoAlimento);
        }

        public void Delete(RefeicaoAlimento refeicaoAlimento)
        {
            _refeicaoAlimentoRepository.Delete(refeicaoAlimento);
        }
    }
}
