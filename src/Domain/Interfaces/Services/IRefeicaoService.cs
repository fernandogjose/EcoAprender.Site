using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IRefeicaoService
    {
        IList<Refeicao> List(Refeicao refeicao);

        void Add(Refeicao refeicao);

        void Update(Refeicao refeicao);

        void Delete(Refeicao refeicao);
    }
}
