using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;
using Domain.ViewModels;
using System.Linq;

namespace Application.Services
{
    public class ComunicadoAppService : BaseAppService<Comunicado>, IComunicadoAppService
    {
        private readonly IComunicadoService _comunicadoService;
        private readonly IComunicadoLeituraUsuarioService _comunicadoLeituraUsuarioService;
        private readonly IComunicadoConfirmarUsuarioService _comunicadoConfirmarUsuarioService;
        private readonly IUsuarioService _usuarioService;

        public ComunicadoAppService(IComunicadoService comunicadoService, IUsuarioService usuarioService, IComunicadoLeituraUsuarioService comunicadoLeituraUsuarioService, IComunicadoConfirmarUsuarioService comunicadoConfirmarUsuarioService)
            : base(comunicadoService)
        {
            _comunicadoService = comunicadoService;
            _usuarioService = usuarioService;
            _comunicadoLeituraUsuarioService = comunicadoLeituraUsuarioService;
            _comunicadoConfirmarUsuarioService = comunicadoConfirmarUsuarioService;
        }

        public override void Remove(Comunicado model)
        {
            _comunicadoLeituraUsuarioService.Remove(x => x.ComunicadoId == model.Id);
            _comunicadoConfirmarUsuarioService.Remove(x => x.ComunicadoId == model.Id);
            base.Remove(model);
        }

        public IList<ComunicadoRelatorioViewModel> Relatorio(Comunicado request)
        {
            var comunicado = _comunicadoService.Get(request.Id);
            var comunicadoLeituraUsuarios = _comunicadoLeituraUsuarioService.GetAll(x => x.ComunicadoId == request.Id);
            var comunicadoConfirmarUsuarios = _comunicadoConfirmarUsuarioService.GetAll(x => x.ComunicadoId == request.Id);
            var usuarios = _usuarioService.GetAll(x => x.PerfilId == 2);

            var response = new List<ComunicadoRelatorioViewModel>();
            foreach (var usuario in usuarios.OrderBy(x => x.Nome))
            {
                var relatorio = new ComunicadoRelatorioViewModel
                {
                    UsuarioId = usuario.Id,
                    UsuarioNome = usuario.Nome,
                    ComunicadoTitulo = comunicado.Titulo,
                    PedirConfirmacao = comunicado.Confirmar,
                };

                foreach (var leitura in comunicadoLeituraUsuarios)
                {
                    if (leitura.UsuarioId == usuario.Id)
                    {
                        relatorio.DataLeitura = leitura.DataAlteracao;
                        break;
                    }
                }

                if (comunicado.Confirmar)
                {
                    foreach (var confirmar in comunicadoConfirmarUsuarios)
                    {
                        if (confirmar.UsuarioId == usuario.Id)
                        {
                            relatorio.DataConfirmado = confirmar.DataAlteracao;
                            break;
                        }
                    }
                }

                response.Add(relatorio);
            }

            return response;
        }
    }
}
