using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IRefeicaoTipoService
    {
        IList<RefeicaoTipo> List(RefeicaoTipo refeicaoTipo);

        void Add(RefeicaoTipo refeicaoTipo);

        void Update(RefeicaoTipo refeicaoTipo);

        void Delete(RefeicaoTipo refeicaoTipo);
    }
}
