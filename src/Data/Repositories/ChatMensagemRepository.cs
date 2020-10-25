using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class ChatMensagemRepository : BaseRepository<ChatMensagem>, IChatMensagemRepository
    {
        public ChatMensagemRepository()
            : base() { }
    }
}
