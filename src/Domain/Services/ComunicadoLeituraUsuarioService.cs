using System.Linq;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ComunicadoLeituraUsuarioService : BaseService<ComunicadoLeituraUsuario>, IComunicadoLeituraUsuarioService
    {
        private readonly IComunicadoLeituraUsuarioRepository _comunicadoLeituraUsuarioRepository;
        public ComunicadoLeituraUsuarioService(IComunicadoLeituraUsuarioRepository comunicadoLeituraUsuarioRepository)
            : base(comunicadoLeituraUsuarioRepository)
        {
            _comunicadoLeituraUsuarioRepository = comunicadoLeituraUsuarioRepository;
        }


        public override void Validate(ComunicadoLeituraUsuario model)
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
            return _comunicadoLeituraUsuarioRepository.GetAll(x => x.UsuarioId == usuarioId && x.ComunicadoId == comunicadoId && x.Id != id).Count();
        }
    }
}
