using Domain.Entities;
using Domain.ViewModels;
using System.Collections.Generic;

namespace Domain.Mappers
{
    public static class ChatMapper
    {
        public static ChatViewModel ObterViewModelPorModel(Chat chat)
        {
            var response = new ChatViewModel
            {
                Id = chat.Id,
                DataInclusao = chat.DataInclusao,
                De = chat.De,
                Para = chat.Para == null ? 0 : chat.Para.Value,
                GrupoParaId = chat.Para == null ? 0 : chat.Para.Value,
                ParaTipo = chat.ParaTipo,
                Assunto = chat.Assunto,
                Mensagem = chat.Mensagem,
                UsuarioDe = UsuarioMapper.ObterViewModelPorModel(chat.UsuarioDe),
                UsuarioPara = UsuarioMapper.ObterViewModelPorModel(chat.UsuarioPara),
                GrupoPara = GrupoMapper.ObterViewModelPorModel(chat.GrupoPara),
                ChatMensagens = ChatMensagemMapper.ObterViewModelsPorModels(chat.ChatMensagens),
            };

            return response;
        }

        public static IList<ChatViewModel> ObterViewModelsPorModels(IList<Chat> chats)
        {
            var response = new List<ChatViewModel>();
            foreach (var item in chats)
            {
                var usuarioViewModel = ObterViewModelPorModel(item);
                response.Add(usuarioViewModel);
            }

            return response;
        }
    }
}