using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IRefeicaoTipoRepository
    {
        IList<RefeicaoTipo> List(RefeicaoTipo refeicaoTipo);

        void Add(RefeicaoTipo refeicaoTipo);

        void Update(RefeicaoTipo refeicaoTipo);

        void Delete(RefeicaoTipo refeicaoTipo);
    }
}