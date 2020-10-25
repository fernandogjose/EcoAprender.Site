using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IRefeicaoStatusService
    {
        IList<RefeicaoStatus> List(RefeicaoStatus refeicaoStatus);

        void Add(RefeicaoStatus refeicaoStatus);

        void Update(RefeicaoStatus refeicaoStatus);

        void Delete(RefeicaoStatus refeicaoStatus);
    }
}
