using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IRefeicaoStatusRepository
    {
        IList<RefeicaoStatus> List(RefeicaoStatus refeicaoStatus);

        void Add(RefeicaoStatus refeicaoStatus);

        void Update(RefeicaoStatus refeicaoStatus);

        void Delete(RefeicaoStatus refeicaoStatus);
    }
}