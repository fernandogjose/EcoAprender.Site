using System.Linq;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class SugestaoRespostaService : BaseService<SugestaoResposta>, ISugestaoRespostaService
    {
        private readonly ISugestaoRespostaRepository _sugestaoRespostaRepository;
        public SugestaoRespostaService(ISugestaoRespostaRepository sugestaoRespostaRepository)
            : base(sugestaoRespostaRepository)
        {
            _sugestaoRespostaRepository = sugestaoRespostaRepository;
        }

        public override void Validate(SugestaoResposta model)
        {
            if (ValidarRespostaDuplicado(model) > 0)
            {
                throw new CommonException(
                    new Error
                    {
                        Mensagem = "Resposta já cadastrada no sistema."
                    });
            }
        }

        public int ValidarRespostaDuplicado(SugestaoResposta model)
        {
            return _sugestaoRespostaRepository.GetAll(x => x.Descricao == model.Descricao && x.SugestaoId == model.SugestaoId && x.Id != model.Id).Count();
        }
    }
}
