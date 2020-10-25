using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using System.IO;
using Domain.Entities;
using Domain.Mappers;

namespace WebApi.Controllers
{
    [RoutePrefix("chat-mensagem")]
    public class ChatMensagemController : ApiController
    {
        private readonly IChatMensagemAppService _chatMensagemAppService;

        public ChatMensagemController(IChatMensagemAppService chatMensagemAppService)
        {
            _chatMensagemAppService = chatMensagemAppService;
        }

        [HttpGet]
        [Route("{pagina:int}/{escolaId:int}")]
        public HttpResponseMessage Index(int pagina, int escolaId)
        {
            pagina = pagina * 5;
            var response = _chatMensagemAppService.GetAll(x => x.EscolaId == escolaId).OrderByDescending(x => x.DataInclusao).Skip(pagina).Take(5).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("listar/{chatId:int}/{ultimoId:int}/{escolaId:int}")]
        public HttpResponseMessage Listar(int chatId, int ultimoId, int escolaId)
        {
            var chatMensagens = _chatMensagemAppService.GetAll(x => x.ChatId == chatId && x.Id > ultimoId && x.EscolaId == escolaId).OrderBy(x => x.Id).ToList();
            var response = ChatMensagemMapper.ObterViewModelsPorModels(chatMensagens);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("responder")]
        public HttpResponseMessage Responder(ChatMensagem request)
        {
            _chatMensagemAppService.Add(request);
            return Request.CreateResponse(HttpStatusCode.OK, "Mensagem enviada com sucesso");
        }
    }
}
