using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ChatService : BaseService<Chat>, IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
            : base(chatRepository)
        {
            _chatRepository = chatRepository;
        }


        public override void Validate(Chat model)
        {
            
        }
    }
}
