using System;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

using System.Collections.Generic;
using System.IO;

namespace Domain.Services
{
    public class ChatMensagemService : BaseService<ChatMensagem>, IChatMensagemService
    {
        private readonly IChatMensagemRepository _chatMensagemRepository;
        public ChatMensagemService(IChatMensagemRepository chatMensagemRepository)
            : base(chatMensagemRepository)
        {
            _chatMensagemRepository = chatMensagemRepository;
        }


        public override void Validate(ChatMensagem model)
        {
            
        }
    }
}
