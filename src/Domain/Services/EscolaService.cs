using System.Linq;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class EscolaService : BaseService<Escola>, IEscolaService
    {
        private readonly IEscolaRepository _escolaRepository;
        public EscolaService(IEscolaRepository escolaRepository)
            : base(escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }


        public override void Validate(Escola model)
        {
            if (ValidarNomeDuplicado(model.Id, model.Nome) > 0)
            {
                throw new CommonException(
                    new Error
                    {
                        Mensagem = "Escola já cadastrada no sistema."
                    });
            }
        }

        public int ValidarNomeDuplicado(int id, string nome)
        {
            return _escolaRepository.GetAll(x => x.Nome == nome && x.Id != id).Count();
        }
    }
}
