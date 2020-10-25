using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Mappers
{
    public static class ChatMensagemMapper
    {
        public static ChatMensagemViewModel ObterViewModelPorModel(ChatMensagem chatMensagem)
        {
            var response = new ChatMensagemViewModel
            {
                Id = chatMensagem.Id,
                De = chatMensagem.De,
                Mensagem = chatMensagem.Mensagem,
                UsuarioDe = UsuarioMapper.ObterViewModelPorModel(chatMensagem.UsuarioDe),
            };

            return response;
        }

        public static IEnumerable<ChatMensagemViewModel> ObterViewModelsPorModels(IEnumerable<ChatMensagem> chatMensagens)
        {
            var response = new List<ChatMensagemViewModel>();
            foreach (var item in chatMensagens)
            {
                var chatMensagemViewModel = ObterViewModelPorModel(item);
                response.Add(chatMensagemViewModel);
            }

            return response;
        }
    }
}