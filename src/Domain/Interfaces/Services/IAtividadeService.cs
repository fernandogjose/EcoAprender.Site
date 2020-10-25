using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IAtividadeService : IBaseService<Atividade>
    {
        string ObterLink(Atividade atividade);

        void SelecionarFotoCapa(Atividade atividade);

        void SelecionarFotoResumo(Atividade atividade);

        void Salvar(Atividade atividade);
    }
}
