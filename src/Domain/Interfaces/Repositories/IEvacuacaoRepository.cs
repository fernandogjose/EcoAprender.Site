using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IEvacuacaoRepository
    {
        IList<Evacuacao> List(Evacuacao evacuacao);

        void Add(Evacuacao evacuacao);

        void Update(Evacuacao evacuacao);

        void Delete(Evacuacao evacuacao);
    }
}