using Domain.Entities;
using System.IO;

namespace Domain.Interfaces.Application
{
    public interface IAtividadeAppService : IBaseAppService<Atividade>
    {
        int SalvarPorApp(Atividade atividade);

        void SelecionarFotoCapa(Atividade atividade);

        void SelecionarFotoResumo(Atividade atividade);
    }
}
