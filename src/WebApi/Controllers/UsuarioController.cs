using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using Domain.Mappers;
using System.Linq;
using Domain.Entities;

namespace WebApi.Controllers
{
    [RoutePrefix("usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        [Route("listar/{escolaId:int}")]
        public HttpResponseMessage Listar(int escolaId)
        {
            var usuario = _usuarioAppService.GetAll(x => x.EscolaId == escolaId).OrderBy(x => x.Nome).ToList();
            var response = UsuarioMapper.ObterViewModelsPorModels(usuario);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("login/{email}/{senha}")]
        public HttpResponseMessage Login(string email, string senha)
        {
            var usuario = _usuarioAppService.Login(email, senha);

            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, "usuário ou senha não encontrado");
            }

            var response = UsuarioMapper.ObterLoginPorUsuario(usuario);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("atualiza-PushNotificationAndroidRegistrationId")]
        public HttpResponseMessage AtualizarToken(Usuario usuario)
        {
            _usuarioAppService.AtualizarToken(usuario);
            return Request.CreateResponse(HttpStatusCode.OK, "token atualizado com sucesso");
        }

        [HttpGet]
        [Route("listar/push-notification-id-por-turma/{escolaId:int}/{grupoId}")]
        public HttpResponseMessage ListarPushNotificationIdPorTurma(int escolaId, int grupoId)
        {
            var pushNotifications = _usuarioAppService.ListarPushNotificationIdPorTurma(escolaId, grupoId);
            return Request.CreateResponse(HttpStatusCode.OK, pushNotifications);
        }
    }
}
