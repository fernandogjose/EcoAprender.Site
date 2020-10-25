using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class ChatAppService : BaseAppService<Chat>, IChatAppService
    {
        private readonly IChatService _chatService;

        public ChatAppService(IChatService chatService)
            : base(chatService)
        {
            _chatService = chatService;
        }

        public override void Add(Chat model)
        {
            if (model.ParaTipo == "usuario")
                model.GrupoParaId = null;
            else
                model.Para = null;

            base.Add(model);
        }
    }
}
