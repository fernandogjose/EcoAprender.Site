using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class ChatMensagemAppService : BaseAppService<ChatMensagem>, IChatMensagemAppService
    {
        private readonly IChatMensagemService _chatMensagemService;

        public ChatMensagemAppService(IChatMensagemService chatMensagemService)
            : base(chatMensagemService)
        {
            _chatMensagemService = chatMensagemService;
        }
    }
}
