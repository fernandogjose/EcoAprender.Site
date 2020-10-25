using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Mappers
{
    public static class UsuarioMapper
    {
        public static ViewModels.LoginViewModel ObterLoginPorUsuario(Usuario usuario)
        {
            if (usuario == null) return null;
            var response = new ViewModels.LoginViewModel
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                Perfil = usuario.Perfil.Nome,
                UsuarioId = usuario.Id,
                UsuarioNome = usuario.Login,
                PushNotificationAndroidRegistrationId = usuario.PushNotificationAndroidRegistrationId,
                Escola = EscolaMapper.ObterViewModelPorModel(usuario.Escola)
            };

            return response;
        }

        public static ViewModels.UsuarioViewModel ObterViewModelPorModel(Usuario usuario)
        {
            if (usuario == null) return null;
            var response = new ViewModels.UsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                PushNotificationAndroidRegistrationId = usuario.PushNotificationAndroidRegistrationId
            };

            return response;
        }

        public static IList<ViewModels.UsuarioViewModel> ObterViewModelsPorModels(IList<Usuario> usuarios)
        {
            var response = new List<ViewModels.UsuarioViewModel>();
            foreach (var usuario in usuarios)
            {
                var usuarioViewModel = ObterViewModelPorModel(usuario);
                response.Add(usuarioViewModel);
            }

            return response;
        }
    }
}