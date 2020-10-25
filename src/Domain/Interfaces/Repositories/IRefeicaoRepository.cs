using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IRefeicaoRepository
    {
        IList<Refeicao> List(Refeicao refeicao);

        void Add(Refeicao refeicao);

        void Update(Refeicao refeicao);

        void Delete(Refeicao refeicao);
    }
}