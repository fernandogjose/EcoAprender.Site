using System.Linq;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class SugestaoService : BaseService<Sugestao>, ISugestaoService
    {
        private readonly ISugestaoRepository _sugestaoRepository;
        public SugestaoService(ISugestaoRepository sugestaoRepository)
            : base(sugestaoRepository)
        {
            _sugestaoRepository = sugestaoRepository;
        }
        
        public override void Validate(Sugestao model)
        {
            if (ValidarTituloDuplicado(model) > 0)
            {
                throw new CommonException(
                    new Error
                    {
                        Mensagem = "Sugestão já cadastrada no sistema."
                    });
            }
        }

        public int ValidarTituloDuplicado(Sugestao model)
        {
            return _sugestaoRepository.GetAll(x => (x.Titulo == model.Titulo || x.Descricao== model.Descricao) && x.Id != model.Id).Count();
        }
    }
}
