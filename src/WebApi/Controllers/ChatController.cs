using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using System.IO;
using Domain.Entities;
using Domain.Mappers;
using System;

namespace WebApi.Controllers
{
    [RoutePrefix("chat")]
    public class ChatController : ApiController
    {
        private readonly IChatAppService _chatAppService;

        public ChatController(IChatAppService chatAppService)
        {
            _chatAppService = chatAppService;
        }

        [HttpGet]
        [Route("listar/{pagina:int}/{usuarioId:int}/{escolaId:int}")]
        public HttpResponseMessage Index(int pagina, int usuarioId, int escolaId)
        {
            pagina = pagina * 5;
            var chats = _chatAppService.GetAll(x => (x.De == usuarioId || x.Para == usuarioId) && x.EscolaId == escolaId).OrderByDescending(x => x.DataInclusao).Skip(pagina).Take(5).ToList();
            var response = ChatMapper.ObterViewModelsPorModels(chats);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("enviar")]
        public HttpResponseMessage Enviar(Chat request)
        {
            _chatAppService.Add(request);
            return Request.CreateResponse(HttpStatusCode.OK, "Mensagem enviada com sucesso");
        }
    }
}
