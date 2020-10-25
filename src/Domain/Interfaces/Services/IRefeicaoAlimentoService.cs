using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IRefeicaoAlimentoService
    {
        IList<RefeicaoAlimento> List(RefeicaoAlimento refeicaoAlimento);

        void Add(RefeicaoAlimento refeicaoAlimento);

        void Update(RefeicaoAlimento refeicaoAlimento);

        void Delete(RefeicaoAlimento refeicaoAlimento);
    }
}
