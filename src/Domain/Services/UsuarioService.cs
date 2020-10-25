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
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public override void Update(Usuario model)
        {
            if (string.IsNullOrEmpty(model.Senha))
            {
                var usuario = Get(model.Id);
                usuario.Nome = model.Nome;
                usuario.Login = model.Login;
                usuario.Email = model.Email;
                usuario.TelefoneResidencial = model.TelefoneResidencial;
                usuario.TelefoneCelular = model.TelefoneCelular;
                usuario.Cpf = model.Cpf;
                usuario.Endereco = model.Endereco;
                usuario.Bairro = model.Bairro;
                usuario.Cep = model.Cep;
                usuario.NomeNoBoleto = model.NomeNoBoleto;
                base.Update(usuario);
                return;
            }

            base.Update(model);
        }

        public override void Validate(Usuario model)
        {
            if (ValidarLoginDuplicado(model.Id, model.Login) > 0)
            {
                throw new CommonException(
                    new Error
                    {
                        Mensagem = "O login já foi cadastrado no sistema."
                    });
            }

            if (model.Id <= 0 && string.IsNullOrEmpty(model.Senha))
            {
                throw new CommonException(
                    new Error
                    {
                        Mensagem = "Senha é obrigatório"
                    });
            }
        }

        private int ValidarLoginDuplicado(int id, string login)
        {
            return _usuarioRepository.GetAll(x => x.Login == login && x.Id != id).Count();
        }

        public Usuario Login(string login, string senha)
        {
            var usuario = _usuarioRepository.Login(login, senha);

            if (usuario == null)
            {
                throw new CommonException(
                    new Error
                    {
                        Mensagem = "Login ou Senha não encontrado!"
                    });
            }

            return usuario;
        }

        public IList<string> ListarPushNotificationIdPorTurma(int escolaId, int grupoId)
        {
            var pushNotifications = new List<string>();
            var usuarios = _usuarioRepository.GetAll(u => u.EscolaId == escolaId);

            foreach (var usuario in usuarios)
            {
                var grupo = usuario.AlunosPais.FirstOrDefault(x => x.Aluno.GrupoId == grupoId);
                if (grupo != null) {
                    pushNotifications.Add(grupo.Usuario.PushNotificationAndroidRegistrationId);
                }
            }

            return pushNotifications;
        }
    }
}
