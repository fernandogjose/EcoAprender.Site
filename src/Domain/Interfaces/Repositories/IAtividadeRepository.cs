using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IAtividadeRepository : IBaseRepository<Atividade>
    {
        void SelecionarFotoCapa(Atividade atividade);

        void SelecionarFotoResumo(Atividade atividade);

        void Salvar(Atividade atividade);
    }
}