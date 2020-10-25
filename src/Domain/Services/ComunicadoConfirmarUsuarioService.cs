using System.Linq;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ComunicadoConfirmarUsuarioService : BaseService<ComunicadoConfirmarUsuario>, IComunicadoConfirmarUsuarioService
    {
        private readonly IComunicadoConfirmarUsuarioRepository _comunicadoConfirmarUsuarioRepository;
        public ComunicadoConfirmarUsuarioService(IComunicadoConfirmarUsuarioRepository comunicadoConfirmarUsuarioRepository)
            : base(comunicadoConfirmarUsuarioRepository)
        {
            _comunicadoConfirmarUsuarioRepository = comunicadoConfirmarUsuarioRepository;
        }


        public override void Validate(ComunicadoConfirmarUsuario model)
        {
            if (ValidarDuplicado(model.Id, model.UsuarioId, model.ComunicadoId) > 0)
            {
                throw new CommonException(
                    new Error
                    {
                        Mensagem = "Confirmação já cadastrada"
                    });
            }
        }

        private int ValidarDuplicado(int id, int usuarioId, int comunicadoId)
        {
            return _comunicadoConfirmarUsuarioRepository.GetAll(x => x.UsuarioId == usuarioId && x.ComunicadoId == comunicadoId && x.Id != id).Count();
        }
    }
}
